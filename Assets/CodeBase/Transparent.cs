using UnityEngine;

namespace CodeBase
{
    public class Transparent : MonoBehaviour
    {
        [Range(0f, 1f)] [SerializeField] private float _maxTransparency = 1f;
        [Range(0f, 1f)] [SerializeField] private float _minTransparency = 0.2f;

        private MeshRenderer _renderer;
        private Color _color;
        private bool _isTransparent;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _color = _renderer.material.color;
        }

        public void ChangeTransparency(bool isTransparent)
        {
            if (_isTransparent == isTransparent)
                return;

            _isTransparent = isTransparent;
            _color.a = _isTransparent ? _minTransparency : _maxTransparency;
            _renderer.material.color = _color;
        }
    }
}