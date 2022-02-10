using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messagesTab;
    [SerializeField] GameObject shopTab;
    // [SerializeField] GameObject expertsTab;

    public void SetMessagesTab()
    {
        shopTab.SetActive(false);
        messagesTab.SetActive(true);
    }

    public void SetShopTab()
    {
        messagesTab.SetActive(false);
        shopTab.SetActive(true);
    }
}
