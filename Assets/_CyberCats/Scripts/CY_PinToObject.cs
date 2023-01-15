using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CY_PinToObject : MonoBehaviour
{
    public Transform Apr_root;
    public Transform CamTransform;
    private void LateUpdate() {
        transform.position = Apr_root.position;
        transform.LookAt(CamTransform.position);

    }
}
