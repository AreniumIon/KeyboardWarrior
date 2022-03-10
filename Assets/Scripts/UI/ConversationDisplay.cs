using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CommentScript;
using System;

public class ConversationDisplay : MonoBehaviour
{
    public static float MESSAGE_TIME = .5f; // Time it takes for player's message to type out
    public static float PAUSE_TIME = .5f; // Time between player's message and NPC typing
    public static float RESPONSE_TIME = .5f; // Time NPC types for
    public static float RESET_TIME = 1f; // Time to load new NPC

    [SerializeField] TextMeshProUGUI conversationText;

    private void Start()
    {
        ResetDisplay();
        CommentScript.commentEvent += StartConversation;
    }

    public void ResetDisplay()
    {
        conversationText.text = "@" + GameController.i.playerController.Username + ":";
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
            conversationText.text += commentString[0];
            commentString = commentString.Remove(0, 1);
            yield return new WaitForSeconds(MESSAGE_TIME / commentLength);
        }

        yield return new WaitForSeconds(PAUSE_TIME);

        // NPC is typing...
        string typingString = "__ is typing...";
        conversationText.text += "\n" + typingString;

        // NPC response
        yield return new WaitForSeconds(RESPONSE_TIME);
        conversationText.text = conversationText.text.Replace(typingString, "");

        bool success = true;
        string responseString;
        if (success) responseString = ConversationGenerator.CreateSuccessReply();
        else responseString = ConversationGenerator.CreateStrikeReply();
        conversationText.text += responseString;

        // Reset
        yield return new WaitForSeconds(RESET_TIME);
        ResetDisplay();
    }
}
