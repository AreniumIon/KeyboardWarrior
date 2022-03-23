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

    private void OnEnable()
    {
        CommentScript.commentEvent += StartConversation;

        ConversationController.changeInConversationEvent += (inConversation) => { if (!inConversation) ResetDisplay(); };

        ConversationController.changeConversationStringEvent += UpdateDisplay;
    }

    private void OnDisable()
    {
        CommentScript.commentEvent -= StartConversation;

        ConversationController.changeInConversationEvent -= (inConversation) => { if (!inConversation) ResetDisplay(); };

        ConversationController.changeConversationStringEvent -= UpdateDisplay;
    }

    private void Start()
    {
        // Update display when returning to Messages state
        GameController.i.keyboardWarriorSM.ChangeStateEvent += (state) =>
        {
            if (state is MessagesState)
            {
                if (ConversationController.InConversation)
                    UpdateDisplay(ConversationController.ConversationString);
                else
                    ResetDisplay();
            }
        };

        ResetDisplay();
    }

    public void StartConversation(ButtonType buttonType)
    {
        if (!ConversationController.InConversation)
            ConversationController.i.DoConversation(buttonType);
    }

    public void ResetDisplay()
    {
        _conversationText.text = "@" + GameController.i.playerController.Username + ": ";
        _profileRoot.AssignNewProfile();
    }

    public void UpdateDisplay(string str)
    {
        _conversationText.text = str;
    }
}
