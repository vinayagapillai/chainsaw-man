using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockStateManager : MonoBehaviour
{
    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            
        }

        
    }
}
