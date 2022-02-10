using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : KeyboardWarriorState
{
    public override void Enter()
    {
        GameController.i.uiController.SetShopTab(true);
    }

    public override void Tick()
    {
        // Maybe run in-game timer here?
        // GameTimer.Tick();
        // GameTimer would trigger all time-related actions, like passive chaos generation
    }

    public override void Exit()
    {
        GameController.i.uiController.SetShopTab(false);
    }
}
