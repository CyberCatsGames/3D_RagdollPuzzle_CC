using ARP.APR.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_FinishEvent : MonoBehaviour
{
    public CinemachineDollyCart CM_Cart;

    private void Update() {
        if(CM_Cart.m_Position >= 1f) {
            this.transform.parent = null;
            GetComponent<CameraController>().enabled = true;
        }
    }
}
