using System.Collections;
using System.Collections.Generic;
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
        return Resources.Load<GameObject>($"Windows/{nameWindow}");
    }


}
