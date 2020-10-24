using UnityEngine;
using UnityEngine.UI;
using WC = WindowsController;

[RequireComponent(typeof(Animator))]
public class Window : MonoBehaviour
{
    [SerializeField]
    private Button closeButton = null;

    [SerializeField]
    private bool optionCloseWindowOnTap;

    [SerializeField]
    private bool optionCloseWindowOnKeyBack;

    private Background background = null;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => CloseWindow());
        InitBackground();
        InitKeyBack();
    }

    private void InitBackground()
    {
        if (optionCloseWindowOnTap)
        {
            background = GameObject.FindGameObjectWithTag("Background").GetComponent<Background>();
            background.OnTap += CloseWindowOnTapBackground;
        }
    }

    private void InitKeyBack()
    {
        if (optionCloseWindowOnKeyBack)
        {
            InputManage.Instance.OnInputKeyBack += CloseWindowOnInputKeyBack;
        }
    }

    private void CloseWindowOnTapBackground()
    {
        if (WC.Instance.TryGetCurOpenWindow(out Window lastWindow))
        {
            if (lastWindow.optionCloseWindowOnTap)
            {
                lastWindow.CloseWindow();
            }
        }
    }

    private void CloseWindowOnInputKeyBack()
    {
        if (WC.Instance.TryGetCurOpenWindow(out Window lastWindow))
        {
            if (lastWindow.optionCloseWindowOnKeyBack)
            {
                lastWindow.CloseWindow();
            }
        }
    }

    private void CloseWindow()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    private void DestroyWindow()  //----------- Используется в анимации закрытия окна
    {
        WC.Instance.RemoveOpenWindowsList(this);
        Debug.LogError("Открыто окон: " + WC.Instance.CountOpenWindowsList());  //----------------------------------Кол-во открытых окон
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
    }

    private void OnDestroy()
    {
        if (optionCloseWindowOnTap)
        {
            background.OnTap -= CloseWindowOnTapBackground;
        }
        if (optionCloseWindowOnKeyBack)
        {
            InputManage.Instance.OnInputKeyBack -= CloseWindowOnInputKeyBack;
        }
    }
}