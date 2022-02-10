using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupGameState : KeyboardWarriorState
{
    bool activated = false;

    public override void Enter()
    {
        CreatePlayer();

        activated = false;
    }

    public override void Tick()
    {
        if (activated == false)
        {
            activated = true;
            stateMachine.ChangeState<MessagesState>();
        }
    }

    public override void Exit()
    {
        activated = false;
    }

    private void CreatePlayer()
    {
        // load player data from save, instantiate player with data
    }
}
