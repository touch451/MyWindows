using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsController
{
    public static WindowsController Instance { private set; get; }

    [SerializeField]
    private Canvas canvas = null;

    // ----------------------------------- Чтобы открывалось только одно окно
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

    public WindowsController()
    {
        SceneManager.activeSceneChanged += TryFindCanvasOnChangedScene;
        Instance = this;
    }

    private void TryFindCanvasOnChangedScene(Scene arg0, Scene arg1)
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
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
            GameObject.Instantiate(window, canvas.transform);

            // ----------------------------------- Чтобы открывалось только одно окно
            //if (curOpenWindow != null)
            //{
            //    GameObject.Destroy(curOpenWindow);
            //    Resources.UnloadUnusedAssets();
            //}
            //curOpenWindow = GameObject.Instantiate(window, canvas.transform);
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


