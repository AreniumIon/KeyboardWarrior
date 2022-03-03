using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] AudioClip tabSound;

    public void ClickMessagesTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is MessagesState)
            return;
        OneShotSoundController.PlayClip2D(tabSound, 1f);
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
    }

    public void ClickShopTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is ShopState)
            return;
        OneShotSoundController.PlayClip2D(tabSound, 1f);
        GameController.i.keyboardWarriorSM.ChangeState<ShopState>();
    }
}
