using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesState : KeyboardWarriorState
{
    public override void Enter()
    {
        GameSceneUIController.i.SetForegroundCanvas(true);
        GameSceneUIController.i.SetMessagesCanvas(true);
    }

    public override void Exit()
    {
        GameSceneUIController.i.SetMessagesCanvas(false);
    }
}
