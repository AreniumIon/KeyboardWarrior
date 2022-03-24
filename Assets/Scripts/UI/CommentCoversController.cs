using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentCoversController : MonoBehaviour
{
    [SerializeField] List<GameObject> _coverObjects = null;

    private void OnEnable()
    {
        SetCovers(ConversationController.InConversation);

        ConversationController.changeInConversationEvent += SetCovers;
    }

    private void OnDisable()
    {
        ConversationController.changeInConversationEvent -= SetCovers;
    }

    private void SetCovers(bool enabled)
    {
        foreach (GameObject obj in _coverObjects)
        {
            obj.SetActive(enabled);
        }
    }
}
