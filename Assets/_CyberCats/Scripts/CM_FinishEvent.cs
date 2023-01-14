using ARP.APR.Scripts;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CM_FinishEvent : MonoBehaviour
{
    public CinemachineDollyCart CM_Cart;
    public float CM_CartSpeed = 0.1f;
    public float StartDelay = 1f;
    public bool ShowPreview = false;

    public UnityEvent CMFinishEvent;

    private void Start() {
        if (ShowPreview) {
            Invoke(nameof(StartPath), StartDelay);
        } else {
            this.transform.parent = null;
            GetComponent<CameraController>().enabled = true;
        }
        
    }
    private void Update() {
        if(CM_Cart.m_Position >= 1f) {
            this.transform.parent = null;
            GetComponent<CameraController>().enabled = true;
            CMFinishEvent?.Invoke();
        }
    }

    void StartPath() {
        CM_Cart.m_Speed = CM_CartSpeed;
    }
}
