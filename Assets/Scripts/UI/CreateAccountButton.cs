using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountButton : MonoBehaviour
{
    public void OnClick()
    {
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
    }
}
