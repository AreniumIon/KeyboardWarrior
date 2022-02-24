using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardWarriorSM : StateMachine
{
    private void Start()
    {
        ChangeState<SetupGameState>();
    }
}