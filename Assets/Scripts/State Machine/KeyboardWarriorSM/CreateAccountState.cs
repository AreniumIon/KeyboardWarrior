using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountState : KeyboardWarriorState
{
    public override void Enter()
    {
        GameController.i.uiController.SetCreateAccountCanvas(true);
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        GameController.i.uiController.SetCreateAccountCanvas(false);
    }
}
