using System;
using CodeBase.Enemies;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace _CyberCats.Scenes.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class FlyingButton : MonoBehaviour
    {
        [SerializeField] private FlyingButton _prefab;
        [SerializeField] private AudioClip[] _audioClip;
        [SerializeField] private TMP_Text _textLabel;
        [SerializeField] private string[] _dialogs;
        [SerializeField] private int _multiplierCount = 2;
        [SerializeField] private UnityEvent _onClickOnSuperButtonToNextLevel;

        [Range(0f, 0.1f)]
        [SerializeField] private float _decreaseScale = 0.05f;

        private AudioSource _audioSource;
        private static Vector3 _currentScale;
        private static bool _isFirst = true;
        private bool _canTouch;
        private bool _buttonToGoToNextLevelActivate;
        private static bool _finishButtonWasCreated;

        public Rigidbody Rigidbody { get; private set; }

        //private AudioClip RandomClip =>
        //    _audioClip[Random.Range(0, _audioClip.Length)];

        private bool _isNotFirstPlay;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();

            if (_isFirst == false)
            {
                _canTouch = true;
            }

            if (_isNotFirstPlay == false && CurrentSceneManager.Instance.Level >= 1)
            {
                _isNotFirstPlay = true;
            }
        }

        private void Start()
        {
            if (_isNotFirstPlay == true && _isFirst)
            {
                print("Press it if you're petuh");
                _textLabel.text = "Нажми если Петух";

                if (_isFirst == true)
                {
                    Invoke(nameof(DoScaleAnimation), 8f);
                }
            }
            else
            {
                if (_finishButtonWasCreated == true)
                    return;

                if (_isFirst == true)
                {
                    Invoke(nameof(DoScaleAnimation), 15f);
                }
                else
                {
                    if (_dialogs.Length > 0)
                    {
                        _textLabel.text = _dialogs[Random.Range(0, _dialogs.Length)];
                    }
                }
            }
        }

        private void DoScaleAnimation()
        {
            transform.DOScale(new Vector3(0.25f, 0.2f, 1f), 1f).OnComplete
            (
                () =>
                {
                    _currentScale = transform.localScale;
                    _isFirst = false;
                    _canTouch = true;
                }
            );
        }

        private void OnMouseEnter()
        {
            if (_isNotFirstPlay == true)
                return;

            Rigidbody.isKinematic = false;
            Rigidbody.AddForceAtPosition(500f * Vector3.one, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        private void OnMouseDown()
        {
            if (_buttonToGoToNextLevelActivate == true)
            {
                _buttonToGoToNextLevelActivate = false;
                _onClickOnSuperButtonToNextLevel?.Invoke();
            }

            if (_canTouch == false)
                return;

            if (_isNotFirstPlay == false)
            {
                for (int i = 0; i < _multiplierCount; i++)
                {
                    FlyingButton flyingButton = Instantiate
                        (_prefab, transform.position + Vector3.one * Random.Range(-2f, 2f), Quaternion.identity);
                    flyingButton.Rigidbody.AddForce(Vector3.one * Random.Range(-2f, 2f) * 20f);
                }
            }
            else
            {
                if (_finishButtonWasCreated == true)
                    return;
                _finishButtonWasCreated = true;
                print("Instatiation");
                Vector3 targetPosition = new Vector3(80.63f, 0f, -843.346f);
                print(targetPosition);
                FlyingButton flyingButton = Instantiate(_prefab, targetPosition, Quaternion.identity);
                flyingButton._textLabel.text = "Ну тебя понял, пендос значит\nНу жми...";
                flyingButton.transform.localScale = Vector3.one;
                _buttonToGoToNextLevelActivate = true;
            }

            //_audioSource.PlayOneShot(RandomClip);
            _currentScale -= Vector3.one * _decreaseScale;
        }

        private void Update()
        {
            if (_isFirst == true || _finishButtonWasCreated)
                return;

            transform.localScale = _currentScale;
        }

        private void OnDestroy()
        {
            _finishButtonWasCreated = false;
            _isFirst = true;
        }
    }
}