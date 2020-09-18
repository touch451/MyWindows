using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    public static WindowsController Instance;

    [SerializeField]
    private Canvas canvas = null;

    [HideInInspector]
    public GameObject curOpenWindow = null;

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
        {WindowType.START_GAME, "Windows/StartWindow"},
        {WindowType.SETTINGS, "Windows/SettingsWindow"},
        {WindowType.STORE, "Windows/StoreWindow"},
        {WindowType.EXIT, "Windows/ExitWindow"},
        {WindowType.QUIT_MENU, "Windows/QuitMenuWindow"}
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

    public void OpenWindow(GameObject window)
    {
        if (curOpenWindow != null)
        {
            Destroy(curOpenWindow);
            //Resources.UnloadUnusedAssets();
        }
        curOpenWindow = Instantiate(window, canvas.transform);
    }

    public GameObject GetWindowByWindowType(WindowType type)
    {
        if (!windowDict.TryGetValue(type, out string pathToResource))
        {
            throw new UnityException($"Не удалось найти путь к ресурсу Window по типу.");
        }
        return Resources.Load<GameObject>(pathToResource);
    }
}
