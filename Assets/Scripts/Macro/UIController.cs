using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject backgroundObj;
    [SerializeField] GameObject foregroundObj;

    [SerializeField] GameObject messagesObj;
    [SerializeField] GameObject shopObj;
    // [SerializeField] GameObject expertsTab;

    public void SetMessagesTab(bool active)
    {
        messagesObj.SetActive(active);
    }

    public void SetShopTab(bool active)
    {
        shopObj.SetActive(active);
    }
}
