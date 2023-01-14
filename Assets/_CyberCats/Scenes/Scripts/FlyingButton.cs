using UnityEngine;

namespace _CyberCats.Scenes.Scripts
{
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

        private AudioClip RandomClip =>
            _audioClip[Random.Range(0, _audioClip.Length)];

        private void Awake()
        {
            _currentScale = transform.localScale;
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            for (int i = 0; i < _multiplierCount; i++)
            {
                Instantiate(_prefab, transform.position, Quaternion.identity);
            }

            _audioSource.PlayOneShot(RandomClip);
            _currentScale -= Vector3.one * _decreaseScale;
        }

        private void Update()
        {
            transform.localScale = _currentScale;
        }
    }
}