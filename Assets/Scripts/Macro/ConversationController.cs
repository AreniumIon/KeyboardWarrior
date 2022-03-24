using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static CommentOutcomeCalc;

public class ConversationController : MonoBehaviour
{
    [SerializeField] ProfileDisplay _npcProfileDisplay;

    public static ConversationController i;

    public static float MESSAGE_TIME = .3f; // Time it takes for player's message to type out
    public static float PAUSE_TIME = .2f; // Time between player's message and NPC typing
    public static float RESPONSE_TIME = .4f; // Time NPC types for
    public static float DELAY_STRIKE_TIME = .75f; // Time game waits to give strike
    public static float RESET_TIME = .1f; // Time before allowing player to input

    static bool inConversation = false;
    public static bool InConversation { get => inConversation; set { inConversation = value; changeInConversationEvent?.Invoke(InConversation); } }
    public static event Action<bool> changeInConversationEvent;

    static string conversationString = "";
    public static string ConversationString { get => conversationString; set { conversationString = value; changeConversationStringEvent?.Invoke(conversationString); } }
    public static event Action<string> changeConversationStringEvent;

    private void Start()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DoConversation(ButtonType buttonType)
    {
        Debug.Assert(!InConversation, "ConversationController.DoConversation called while already in conversation.");

        InConversation = true;

        StartCoroutine(ConversationRunner(buttonType, _npcProfileDisplay.username));
    }
    
    private static IEnumerator ConversationRunner(ButtonType buttonType, string npcName)
    {
        ConversationString = "@" + GameController.i.playerController.Username + ": ";

        string commentString = ConversationGenerator.CreatePlayerComment(buttonType);
        int commentLength = commentString.Length;
        // TODO: NPC's have username

        // Player message
        while (commentString != "")
        {
            ConversationString += commentString[0];
            commentString = commentString.Remove(0, 1);
            yield return new WaitForSeconds(MESSAGE_TIME / commentLength);
        }

        yield return new WaitForSeconds(PAUSE_TIME);

        // NPC is typing...
        string typingString = npcName + " is typing...";
        ConversationString += "\n" + typingString;

        // NPC response
        yield return new WaitForSeconds(RESPONSE_TIME);
        ConversationString = ConversationString.Replace(typingString, "");

        bool success = CommentOutcomeCalc.RollSuccess(buttonType);
        string responseString = success ? ConversationGenerator.CreateSuccessReply(buttonType) : ConversationGenerator.CreateStrikeReply();
        ConversationString += responseString;

        // Success
        if (success)
        {
            CommentOutcomeCalc.OnSuccess(buttonType);

            // Reset
            yield return new WaitForSeconds(RESET_TIME);
        }
        // Strike
        else
        {
            yield return new WaitForSeconds(DELAY_STRIKE_TIME);
            CommentOutcomeCalc.OnStrike(buttonType);
        }


        InConversation = false;
    }
}
