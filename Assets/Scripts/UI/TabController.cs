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
    }

    public void ClickShopTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is ShopState)
            return;
        GameController.i.keyboardWarriorSM.ChangeState<ShopState>();
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
