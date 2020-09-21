using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Window : MonoBehaviour
{
    [SerializeField]
    Button closeButton = null;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => CloseWindow());
    }

    public void CloseWindow()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    private void DestroyWindow()  //----------- Используется в анимации закрытия окна
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
    }

}
