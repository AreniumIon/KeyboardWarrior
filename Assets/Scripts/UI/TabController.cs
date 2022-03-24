using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] AudioClip tabSound;

    [Header("Object Pooling")]
    [SerializeField] TabSoundPool _tabSoundPool = null;

    public void ClickMessagesTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is MessagesState)
            return;
        //OneShotSoundController.PlayClip2D(tabSound, 1f);
        TabOneShotSound newTabSound = _tabSoundPool.ActivateFromPool();
        
        newTabSound.AssignTabSoundPool(_tabSoundPool);
        newTabSound.gameObject.SetActive(true);
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
    }

    public void ClickShopTab()
    {
        if (GameController.i.keyboardWarriorSM.CurrentState is ShopState)
            return;
        //OneShotSoundController.PlayClip2D(tabSound, 1f);
        TabOneShotSound newTabSound = _tabSoundPool.ActivateFromPool();
        
        newTabSound.AssignTabSoundPool(_tabSoundPool);
        newTabSound.gameObject.SetActive(true);
        GameController.i.keyboardWarriorSM.ChangeState<ShopState>();
    }

  
}
