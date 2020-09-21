using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    public static SceneController Instance { private set; get; }
    public enum SceneType
    {
        NO_TYPE,
        MAIN_MENU,
        GAME
    }

    private Dictionary<SceneType, string> sceneDict = new Dictionary<SceneType, string>()
    {
        {SceneType.MAIN_MENU, "MainMenu"},
        {SceneType.GAME, "Game"},
    };

    public SceneController()
    {
        Instance = this;
    }

    public void LoadScene(SceneType sceneType)
    {
        string sceneName = GetSceneBySceneType(sceneType);

        if (sceneName == null)
        {
            Debug.LogError("Открыть Scene не удалось. Объект не найден.");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public string GetSceneBySceneType(SceneType type)
    {
        if (!sceneDict.TryGetValue(type, out string sceneName))
        {
            throw new UnityException($"Не удалось найти имя Scene в словаре.");
        }
        return sceneName;
    }
}
