using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase
{
    public class DialogOnHead : MonoBehaviour
    {
        [Header("RandomTimeToOpenDialogs")]
        [SerializeField] private float _minTimeToOpen = 10f;

        [SerializeField] private float _maxTimeToOpen = 50f;

        [Space(10)]
        [SerializeField] private string[] _dialogs;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Time")]
        [SerializeField] private float _openTime = 0.5f;

        [SerializeField] private float _closeTime = 0.5f;

        [SerializeField] private float _breakTimeAfterRead = 3f;
        [SerializeField] private float _stepTime = 0.05f;

        private Coroutine _coroutine;
        private bool _isClosing;
        private bool _isReading;
        private float _timerToOpenDialog;

        private bool CanRead => _isReading == false && _coroutine == null;

        private void Start()
        {
            SetRandomTimeToOpenDialog();
        }

        private void Update()
        {
            _timerToOpenDialog -= Time.deltaTime;

            if (_timerToOpenDialog <= 0f && CanRead == true)
                OpenRandomDialog();
        }

        public void OpenDialog(int index)
        {
            if (CanRead == false)
                return;

            _text.text = string.Empty;
            string dialog = _dialogs[index];
            _canvasGroup.DOFade(1f, _openTime);
            _coroutine = StartCoroutine(Read(dialog));
        }

        private void OpenRandomDialog()
        {
            OpenDialog(Random.Range(0, _dialogs.Length));
        }

        private IEnumerator Read(string dialog)
        {
            WaitForSeconds waitForSeconds = new(_stepTime);

            foreach (char symbol in dialog)
            {
                _text.text += symbol;
                yield return waitForSeconds;
            }

            yield return new WaitForSeconds(_breakTimeAfterRead);
            CloseDialog();
        }

        private void CloseDialog(Action callback = null)
        {
            _canvasGroup.DOFade(0f, _closeTime)
                .OnComplete
                (
                    () =>
                    {
                        SetRandomTimeToOpenDialog();
                        _coroutine = null;
                        _isReading = false;
                        callback?.Invoke();
                    }
                );
        }

        private void SetRandomTimeToOpenDialog()
        {
            _timerToOpenDialog = Random.Range(_minTimeToOpen, _maxTimeToOpen);
        }
    }
}