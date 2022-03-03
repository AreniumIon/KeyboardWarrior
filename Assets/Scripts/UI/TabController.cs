using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] GameObject messagesButton;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject saveButton;


    public void ClickMessagesTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is MessagesState)
            return;
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
        SetMessagesButton(true);
        SetShopButton(true);
        SetSaveButton(true);
    }

    public void ClickShopTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is ShopState)
            return;
        GameController.i.keyboardWarriorSM.ChangeState<ShopState>();
        SetMessagesButton(false);
        SetShopButton(false);
        SetSaveButton(false);
    }

    public void SetMessagesButton(bool active)
    {
        messagesButton.SetActive(active);
    }

    public void SetShopButton(bool active)
    {
        shopButton.SetActive(active);
    }

    public void SetSaveButton(bool active)
    {
        saveButton.SetActive(active);
    }
}
