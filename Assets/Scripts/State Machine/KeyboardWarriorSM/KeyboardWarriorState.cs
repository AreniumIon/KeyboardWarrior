using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardWarriorState : State
{
    protected KeyboardWarriorSM stateMachine { get; private set; }

    private void Awake()
    {
        stateMachine = GetComponent<KeyboardWarriorSM>();
    }
}
