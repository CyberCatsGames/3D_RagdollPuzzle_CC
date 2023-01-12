using ARP.APR.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_FinishEvent : MonoBehaviour
{
    public CinemachineDollyCart CM_Cart;
    public float StartDelay = 1f;
    public bool ShowPreview = false;


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
        }
    }

    void StartPath() {
        CM_Cart.m_Speed = 0.15f;
    }
}
