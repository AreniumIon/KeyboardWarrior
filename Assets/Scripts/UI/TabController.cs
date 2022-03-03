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
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
        OneShotSoundController.PlayClip2D(tabSound, 1f);
    }

    public void ClickShopTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is ShopState)
            return;
        GameController.i.keyboardWarriorSM.ChangeState<ShopState>();
        OneShotSoundController.PlayClip2D(tabSound, 1f);
    }
}
