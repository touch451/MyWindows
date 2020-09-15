using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    //[SerializeField]
    //private WindowsController.WindowsType windowType = default;

    public void OpenWindow()
    {
        WindowsController.Instance.OpenWindow();
    }

    public void CloseWindow()
    {
        WindowsController.Instance.CloseWindow();
    }

}
