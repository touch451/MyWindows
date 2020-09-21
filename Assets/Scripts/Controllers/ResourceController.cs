using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public static ResourceController Instance = null;

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

    public GameObject LoadResourceWindow(string nameWindow)
    {
        return Resources.Load<GameObject>($"Windows/{nameWindow}");
    }


}
