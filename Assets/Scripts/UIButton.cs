﻿using System.Collections;
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
        WindowsController.Instance.OpenWindow(windowType);
    }

    public void LoadScene()
    {
        SceneController.Instance.LoadScene(sceneType);
    } 


}
