using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CommentScript;

public class ConversationDisplay : MonoBehaviour
{
    public static float MESSAGE_TIME = .5f; // Time it takes for player's message to type out
    public static float PAUSE_TIME = .5f; // Time between player's message and NPC typing
    public static float RESPONSE_TIME = .5f; // Time NPC types for

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

        while (commentString != "")
        {
            conversationText.text += commentString[0];
            commentString = commentString.Remove(0, 1);
            yield return new WaitForSeconds(MESSAGE_TIME / commentLength);
        }

        yield return new WaitForSeconds(1f);

        ResetDisplay();
    }
}
