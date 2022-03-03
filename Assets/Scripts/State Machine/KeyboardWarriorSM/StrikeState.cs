using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeState : KeyboardWarriorState
{
    

    public override void Enter()
    {
        GameSceneUIController.i.SetForegroundCanvas(false);
        GameSceneUIController.i.SetStrikeCanvas(true);
        
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        GameSceneUIController.i.SetStrikeCanvas(false);
    }
}
