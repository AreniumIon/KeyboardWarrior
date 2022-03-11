using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CommentOutcomeCalc;
using System;

public class ConversationDisplay : MonoBehaviour
{
    public static float MESSAGE_TIME = .5f; // Time it takes for player's message to type out
    public static float PAUSE_TIME = .5f; // Time between player's message and NPC typing
    public static float RESPONSE_TIME = .5f; // Time NPC types for
    public static float DELAY_STRIKE_TIME = .5f; // Time game waits to give strike
    public static float RESET_TIME = 1f; // Time to load new NPC

    [SerializeField] TextMeshProUGUI _conversationText;

    [SerializeField] ProfileDisplay _profileRoot;

    private void Start()
    {
        ResetDisplay();
        CommentScript.commentEvent += StartConversation;

        // Reset display when returning to Messages state
        GameController.i.keyboardWarriorSM.ChangeStateEvent += (state) => { if (state is MessagesState) ResetDisplay(); };
    }

    public void ResetDisplay()
    {
        _conversationText.text = "@" + GameController.i.playerController.Username + ": ";
        _profileRoot.AssignNewProfile();
    }

    public void StartConversation(ButtonType buttonType)
    {
        StartCoroutine(DoConversation(buttonType));
    }

    public IEnumerator DoConversation(ButtonType buttonType)
    {
        string commentString;
        switch (buttonType)
        {
            case ButtonType.Safe: commentString = ConversationGenerator.CreateNormalComment(); break;
            case ButtonType.Sarcastic: commentString = ConversationGenerator.CreateSarcasticComment(); break;
            case ButtonType.Troll: commentString = ConversationGenerator.CreateTrollComment(); break;
            default: throw new System.Exception();
        }
        int commentLength = commentString.Length;
        // TODO: NPC's have username

        // Player message
        while (commentString != "")
        {
            _conversationText.text += commentString[0];
            commentString = commentString.Remove(0, 1);
            yield return new WaitForSeconds(MESSAGE_TIME / commentLength);
        }

        yield return new WaitForSeconds(PAUSE_TIME);

        // NPC is typing...
        string typingString = "__ is typing...";
        _conversationText.text += "\n" + typingString;

        // NPC response
        yield return new WaitForSeconds(RESPONSE_TIME);
        _conversationText.text = _conversationText.text.Replace(typingString, "");

        bool success = CommentOutcomeCalc.RollSuccess(buttonType);
        string responseString = success ? ConversationGenerator.CreateSuccessReply() : ConversationGenerator.CreateStrikeReply();
        _conversationText.text += responseString;

        // Success
        if (success)
        {
            CommentOutcomeCalc.OnSuccess(buttonType);

            // Reset
            yield return new WaitForSeconds(RESET_TIME);
            ResetDisplay();
        }
        // Strike
        else
        {
            yield return new WaitForSeconds(DELAY_STRIKE_TIME);
            CommentOutcomeCalc.OnStrike(buttonType);
        }

    }
}
