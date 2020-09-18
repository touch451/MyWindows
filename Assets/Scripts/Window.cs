using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Window : MonoBehaviour
{
    public static Window Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    public void CloseWindow()
    {
        WindowsController.Instance.curOpenWindow.GetComponent<Animator>().SetTrigger("Close");
    }


    private void DestroyWindow()  //----------- Используется в анимации закрытия окна
    {
        Destroy(WindowsController.Instance.curOpenWindow);
        Resources.UnloadUnusedAssets();
    }

}
