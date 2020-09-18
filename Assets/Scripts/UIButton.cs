using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    private WindowsController.WindowType windowType = default;

    [SerializeField]
    private SceneController.SceneType sceneType = default;

    public void OpenWindow()
    {
        GameObject window = WindowsController.Instance.GetWindowByWindowType(windowType);

        if(window == null)
        {
            Debug.LogError("Открыть Window не удалось. Объект не найден.");
        }
        else
        {
            WindowsController.Instance.OpenWindow(window);
        }
    }

    public void CloseWindow()
    {
        Window.Instance.CloseWindow();
    }

    public void LoadScene()
    {
        string sceneName = SceneController.Instance.GetSceneBySceneType(sceneType);
                
        if (sceneName == null)
        {
            Debug.LogError("Открыть Scene не удалось. Объект не найден.");
        }
        else
        {
            SceneController.Instance.LoadScene(sceneName);
        }
    } 


}
