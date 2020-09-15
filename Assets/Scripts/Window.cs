using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private void DestroyWindow()  //----------- Используется в анимации закрытия окна
    {
        Destroy(WindowsController.Instance.curOpenWindow);
    }

}
