using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class DialogComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _targetText;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private bool _oneTimeOpen;

        [Header("Time")]
        [SerializeField] private float _openTime = 0.5f;

        [SerializeField] private float _stepTime = 0.05f;
        [SerializeField] private float _closeTime = 0.5f;

        private Coroutine _coroutine;
        private bool _readIt;
        private bool _isReading;
        private bool _isClosing;

        private void Awake()
        {
            ResetDialog();
        }

        public void OpenDialog()
        {
            if (_oneTimeOpen == true && _readIt == true || _isReading || _isClosing)
                return;

            Activate();
        }

        public void CloseDialog()
        {
            if (_isClosing == true)
                return;

            _isClosing = true;
            _canvasGroup.DOFade(0f, _closeTime)
                .OnComplete
                (
                    () =>
                    {
                        _canvasGroup.gameObject.SetActive(false);
                        ResetDialog();
                    }
                )
                .SetEase(Ease.Linear);
        }

        private void Activate()
        {
            _isReading = true;
            _readIt = true;
            _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, _openTime).SetEase(Ease.Linear);
            _coroutine ??= StartCoroutine(Read());
        }

        private IEnumerator Read()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_stepTime);

            foreach (char symbol in _targetText)
            {
                _text.text += symbol;
                yield return waitForSeconds;
            }

            _isReading = false;
            _coroutine = null;
        }

        private void ResetDialog()
        {
            _text.text = "";
            _isClosing = false;
            _isReading = false;
            _canvasGroup.alpha = 0f;
            _canvasGroup.gameObject.SetActive(false);
        }
    }
}