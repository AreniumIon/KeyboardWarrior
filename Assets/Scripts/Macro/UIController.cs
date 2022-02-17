using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject backgroundCanvas;
    [SerializeField] GameObject foregroundCanvas;

    [SerializeField] GameObject messagesCanvas;
    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject strikeCanvas;
    [SerializeField] GameObject createAccountCanvas;
    // [SerializeField] GameObject expertsCanvas;

    public void SetBackgroundCanvas(bool active)
    {
        backgroundCanvas.SetActive(active);
    }

    public void SetForegroundCanvas(bool active)
    {
        foregroundCanvas.SetActive(active);
    }

    public void SetMessagesCanvas(bool active)
    {
        messagesCanvas.SetActive(active);
    }

    public void SetShopCanvas(bool active)
    {
        shopCanvas.SetActive(active);
    }

    public void SetStrikeCanvas(bool active)
    {
        strikeCanvas.SetActive(active);
    }

    public void SetCreateAccountCanvas(bool active)
    {
        createAccountCanvas.SetActive(active);
    }
}
