using UnityEngine;

public class ResourceController
{
    public static ResourceController Instance { private set; get; }

    public ResourceController()
    {
        Instance = this;
    }

    public GameObject LoadResourceWindow(string nameWindow)
    {
        GameObject loadWindow = Resources.Load<GameObject>($"Windows/{nameWindow}");

        if (loadWindow == null)
        {
            throw new UnityException($"Ресурс {nameWindow} не найден.");
        }
        else
        {
            return loadWindow;
        }
    }
}
