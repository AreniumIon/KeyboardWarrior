using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnticipationState : KeyboardWarriorState
{
    public override void Enter()
    {
        Debug.Log("Anticipation state entered");
        StartCoroutine(PeopleTyping());
    }

    IEnumerator PeopleTyping()
    {
        Debug.Log("People are Typing...");
        yield return new WaitForSeconds(.4f);
        Debug.Log("Troll complete!");
        GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
    }

}
