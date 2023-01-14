using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _CyberCats.Scenes.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class FlyingButton : MonoBehaviour
    {
        [SerializeField] private FlyingButton _prefab;
        [SerializeField] private AudioClip[] _audioClip;
        [SerializeField] private int _multiplierCount = 2;

        [Range(0f, 0.1f)]
        [SerializeField] private float _decreaseScale = 0.05f;

        private AudioSource _audioSource;
        private static Vector3 _currentScale;
        private static bool _isFirst = true;
        private bool _canTouch;
        private Rigidbody _rigidbody;

        private AudioClip RandomClip =>
            _audioClip[Random.Range(0, _audioClip.Length)];

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();

            if (_isFirst == false)
            {
                _canTouch = true;
            }
        }

        private void Start()
        {
            if (_isFirst == true)
            {
                Invoke(nameof(DoScaleAnimation), 5f);
            }
        }

        private void DoScaleAnimation()
        {
            print("DOScaleAnimation");
            transform.DOScale(Vector3.one * 0.44315f, 1f).OnComplete
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
            _rigidbody.isKinematic = false;
            _rigidbody.AddForceAtPosition(1000f * Vector3.one, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        private void OnMouseDown()
        {
            if (_canTouch == false)
                return;

            for (int i = 0; i < _multiplierCount; i++)
            {
                Instantiate(_prefab, transform.position, Quaternion.identity);
            }

            _audioSource.PlayOneShot(RandomClip);
            _currentScale -= Vector3.one * _decreaseScale;
        }

        private void Update()
        {
            if (_isFirst == true)
                return;

            transform.localScale = _currentScale;
        }
    }
}