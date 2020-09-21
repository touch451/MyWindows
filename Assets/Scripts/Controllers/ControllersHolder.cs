using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersHolder : MonoBehaviour
{
    public static ControllersHolder Instance { private set; get; }
    public SceneController SceneController { private set; get; }
    public WindowsController WindowsController { private set; get; }
    public ResourceController ResourceController { private set; get; }


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

        SceneController = new SceneController();
        WindowsController = new WindowsController();
        ResourceController = new ResourceController();
    }


}
