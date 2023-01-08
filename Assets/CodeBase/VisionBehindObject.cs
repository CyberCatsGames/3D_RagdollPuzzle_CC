using UnityEngine;

namespace CodeBase
{
    public class VisionBehindObject : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private LayerMask _layer;

        private Transparent _currentTransparent;

        private void Update()
        {
            Vector3 direction = _player.position - transform.position;
            float distance = Vector3.Distance(_player.position, transform.position);
            Debug.DrawRay(transform.position, direction.normalized * distance, Color.red);
            
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance, _layer))
            {
                Transparent transparent = hit.transform.GetComponent<Transparent>();

                if (transparent != null)
                {
                    if (_currentTransparent != null && _currentTransparent != transparent)
                    {
                        _currentTransparent.ChangeTransparency(false);
                    }

                    transparent.ChangeTransparency(true);
                    _currentTransparent = transparent;
                }
            }
            else if (_currentTransparent != null)
            {
                _currentTransparent.ChangeTransparency(false);
            }
        }
    }
}