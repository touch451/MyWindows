using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManage : MonoBehaviour
{
    public static Action OnInputKeyBack = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnInputKeyBack.Invoke();
        }
    }



    
}



