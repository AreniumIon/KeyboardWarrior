using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeState : KeyboardWarriorState
{
    public override void Enter()
    {
        GameController.i.uiController.SetForegroundCanvas(false);
        GameController.i.uiController.SetStrikeCanvas(true);
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        GameController.i.uiController.SetStrikeCanvas(false);
    }
}
