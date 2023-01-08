using UnityEngine;
using UnityEngine.Events;

namespace CodeBase
{
    public class TriggerObserver : MonoBehaviour
    {
        [SerializeField] private UnityEvent _enter;
        [SerializeField] private UnityEvent _stay;
        [SerializeField] private UnityEvent _exit;
        
        [SerializeField] private LayerMask _layer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _enter?.Invoke();
                print("Enter");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _stay?.Invoke();
                print("Stay");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                print("Exit");
                _exit?.Invoke();
            }
        }
    }
}