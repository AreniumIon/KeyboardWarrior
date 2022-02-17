using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountButton : MonoBehaviour
{
    // TODO: Reference to text box where user can type in their username.

    public void OnClick()
    {
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
    }
}
