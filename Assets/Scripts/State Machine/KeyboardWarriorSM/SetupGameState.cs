using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupGameState : KeyboardWarriorState
{
    bool hasSaveData;
    bool decided = false;

    public override void Enter()
    {
        hasSaveData = PlayerPrefs.GetInt("HasSaveData") == 1;

        decided = true;
    }

    public override void Tick()
    {
        if (decided)
        {
            GameSceneUIController.i.SetForegroundCanvas(false);
            GameSceneUIController.i.SetMessagesCanvas(false);
            GameSceneUIController.i.SetShopCanvas(false);
            GameSceneUIController.i.SetCreateAccountCanvas(false);

            if (hasSaveData)
                stateMachine.ChangeState<MessagesState>();
            else
                stateMachine.ChangeState<CreateAccountState>();
        }
    }

    public override void Exit()
    {
        decided = false;
    }
}
