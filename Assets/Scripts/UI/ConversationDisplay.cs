using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationDisplay : MonoBehaviour
{
    public static float MESSAGE_TIME = .5f; // Time it takes for player's message to type out
    public static float PAUSE_TIME = .5f; // Time between player's message and NPC typing
    public static float RESPONSE_TIME = .5f; // Time NPC types for

    [SerializeField] TextMeshProUGUI conversationText;

    private void Start()
    {
        ResetDisplay();
    }

    public void ResetDisplay()
    {
        conversationText.text = "@" + GameController.i.playerController.Username + ":";
    }

    public void StartConversation()
    {
        StartCoroutine(DoConversation());
    }

    public IEnumerator DoConversation()
    {
        string commentString = ConversationGenerator.CreateNormalComment();
        // TODO: NPC's have username

        yield return null;
    }
}
