using UnityEngine;
using UnityEngine.Events;

namespace CodeBase
{
    public class TriggerObserver : MonoBehaviour
    {
        [SerializeField] private UnityEvent _enter;
        [SerializeField] private UnityEvent _stay;
        [SerializeField] private UnityEvent _exit;
        [SerializeField] private UnityEvent _win;
        [SerializeField] private UnityEvent _alone;
        
        [SerializeField] private LayerMask _layer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer))
            {
                _enter?.Invoke();
                print("Enter");
                if (other.gameObject.tag == "CanBeGrabbed") {
                    print("Saske");
                    Debug.Log(other.gameObject.ToString());
                    _win?.Invoke();
                }
                else {
                    print("alone");
                    _alone?.Invoke();
                }
                
            }
        }

        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.gameObject.IsInLayer(_layer))
        //    {
        //        _stay?.Invoke();
        //        print("Stay");
        //    }
        //}

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