using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    public static WindowsController Instance;

    [SerializeField]
    private Canvas canvas = null;

    [SerializeField]
    private GameObject windowPref = null;

    public GameObject curOpenWindow = null;

    Animator anim = null;

    //public enum WindowsType
    //{
    //    START_GAME,
    //    SETTINGS,
    //    STORE,
    //    EXIT,
    //    CLOSE_WINDOW
    //}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenWindow()
    {
        if (curOpenWindow != null)
        {
            Destroy(curOpenWindow);
        }

        curOpenWindow = Instantiate(windowPref, canvas.transform);
        anim = curOpenWindow.GetComponent<Animator>();
    }

    public void CloseWindow()
    {
        if (curOpenWindow != null)
        {
            anim.SetTrigger("Close");
        }
    }
}
