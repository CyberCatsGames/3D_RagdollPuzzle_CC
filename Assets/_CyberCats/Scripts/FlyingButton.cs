using DG.Tweening;
using TMPro;
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
        [SerializeField] private TMP_Text _textLabel;
        [SerializeField] private string[] _dialogs;
        [SerializeField] private int _multiplierCount = 2;

        [Range(0f, 0.1f)]
        [SerializeField] private float _decreaseScale = 0.05f;

        private AudioSource _audioSource;
        private static Vector3 _currentScale;
        private static bool _isFirst = true;
        private bool _canTouch;
        public Rigidbody Rigidbody { get; private set; }

        //private AudioClip RandomClip =>
        //    _audioClip[Random.Range(0, _audioClip.Length)];

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
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
                Invoke(nameof(DoScaleAnimation), 1f);
            }
            else
            {
                if (_dialogs.Length > 0)
                {
                    _textLabel.text = _dialogs[Random.Range(0, _dialogs.Length)];
                }
            }
        }

        private void DoScaleAnimation()
        {
            
            transform.DOScale(Vector3.one * 0.3f, 1f).OnComplete
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
            Rigidbody.isKinematic = false;
            Rigidbody.AddForceAtPosition(500f * Vector3.one, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        private void OnMouseDown()
        {
            if (_canTouch == false)
                return;

            for (int i = 0; i < _multiplierCount; i++)
            {
                FlyingButton flyingButton = Instantiate
                    (_prefab, transform.position + Vector3.one * Random.Range(-2f, 2f), Quaternion.identity);
                flyingButton.Rigidbody.AddForce(Vector3.one * Random.Range(-2f, 2f) * 20f);
            }

            //_audioSource.PlayOneShot(RandomClip);
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