using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    public static WindowsController Instance;

    [SerializeField]
    private Canvas canvas = null;

    //[HideInInspector]
    //public GameObject curOpenWindow = null;

    public enum WindowType
    {
        NO_TYPE,
        START_GAME,
        SETTINGS,
        STORE,
        EXIT,
        QUIT_MENU
    }

    private Dictionary<WindowType, string> windowDict = new Dictionary<WindowType, string>()
    {
        {WindowType.START_GAME, "StartWindow"},
        {WindowType.SETTINGS, "SettingsWindow"},
        {WindowType.STORE, "StoreWindow"},
        {WindowType.EXIT, "ExitWindow"},
        {WindowType.QUIT_MENU, "QuitMenuWindow"}
    };


    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (canvas == null)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }
    }

    public void OpenWindow(WindowType windowType)
    {
        GameObject window = GetWindowByWindowType(windowType);

        if (window == null)
        {
            Debug.LogError("Открыть Window не удалось. Ресурс не найден.");
        }
        else
        {
            //if (curOpenWindow != null)
            //{
            //    Destroy(curOpenWindow);
            //    Resources.UnloadUnusedAssets();
            //}
            //curOpenWindow = Instantiate(window, canvas.transform);
            Instantiate(window, canvas.transform);
        }
    }

    public GameObject GetWindowByWindowType(WindowType type)
    {
        if (!windowDict.TryGetValue(type, out string nameWindow))
        {
            throw new UnityException($"Не удалось найти имя Window в словаре.");
        }

        return ResourceController.Instance.LoadResourceWindow(nameWindow);
    }

    

}


