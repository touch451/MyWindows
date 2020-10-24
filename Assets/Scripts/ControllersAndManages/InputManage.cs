using System;
using UnityEngine;

public class InputManage : MonoBehaviour
{
    public Action OnInputKeyBack = null;
    public static InputManage Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OnInputKeyBack != null)
            {
                OnInputKeyBack.Invoke();
            }
        }
    }
}