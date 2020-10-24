using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsController
{
    public static WindowsController Instance { private set; get; }

    private Canvas canvas = null;

    private List<Window> openWindowsList = new List<Window>();

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
        Window window = GetWindowByWindowType(windowType);

        if (window == null)
        {
            Debug.LogError("Открыть Window не удалось. Ресурс не найден.");
        }
        else
        {
            Window newWindow = GameObject.Instantiate(window, canvas.transform);
            openWindowsList.Add(newWindow);
            Debug.LogWarning("Открыто окон: " + openWindowsList.Count);  //----------------------------------Кол-во открытых окон
        }
    }

    private Window GetWindowByWindowType(WindowType type)
    {
        if (!windowDict.TryGetValue(type, out string nameWindow))
        {
            throw new UnityException($"Не удалось найти имя Window в словаре.");
        }
        GameObject loadWindow = ResourceController.Instance.LoadResourceWindow(nameWindow);

        return loadWindow.GetComponent<Window>();
    }

    public bool TryGetCurOpenWindow(out Window window)
    {
        if (openWindowsList.Count > 0)
        {
            window = openWindowsList[openWindowsList.Count - 1];
        }
        else
        {
            window = null;
        }
        return window != null;
    }

    public void RemoveOpenWindowsList(Window window)
    {
        openWindowsList.Remove(window);
    }

    public int CountOpenWindowsList()
    {
        return openWindowsList.Count;
    }
}