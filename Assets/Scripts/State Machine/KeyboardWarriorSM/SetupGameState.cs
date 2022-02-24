﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetupGameState : KeyboardWarriorState
{
    bool decided = false;

    public override void Enter()
    {
        // TODO: Decide which state to go to based on if player has progress or is playing fresh
        // switch(playerProgress)...
        decided = true;
    }

    public override void Tick()
    {
        if (decided)
        {
            stateMachine.ChangeState<CreateAccountState>();
        }
    }

    public override void Exit()
    {
        decided = false;
    }
}
