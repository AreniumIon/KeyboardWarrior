using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUIController : MonoBehaviour
{
    public static GameSceneUIController i;
    byte darkColor = 175;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] GameObject backgroundCanvas;
    [SerializeField] GameObject foregroundCanvas;

    [SerializeField] GameObject messagesCanvas;
    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject strikeCanvas;
    [SerializeField] GameObject createAccountCanvas;
    [SerializeField] Image messagesTab;
    [SerializeField] Image shopTab;
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
        if (active)
        {
            //change tab sprite to lighter color
            messagesTab.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            //change tab sprite to darker color
            messagesTab.color = new Color32(darkColor, darkColor, darkColor, 255);
        }
    }

    public void SetShopCanvas(bool active)
    {
        shopCanvas.SetActive(active);
        if (active)
        {
            //change tab sprite to lighter color
            shopTab.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            //change tab sprite to darker color
            shopTab.color = new Color32(darkColor, darkColor, darkColor, 255);
        }
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
