using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
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
}
