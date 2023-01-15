using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CY_Cursor : MonoBehaviour
{
    
   public void EnableCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DisableCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
