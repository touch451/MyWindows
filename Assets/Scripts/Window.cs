using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Window : MonoBehaviour
{
    [SerializeField]
    Button closeButton = null;

    [SerializeField]
    public bool optionCloseWindowOnTap;

    [SerializeField]
    public bool optionCloseWindowOnKeyBack;

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
        WindowsController.Instance.openWindowsList.Remove(gameObject);
        Debug.LogError("Открыто окон: " + WindowsController.Instance.openWindowsList.Count);  //----------------------------------Кол-во открытых окон
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
    }
}
