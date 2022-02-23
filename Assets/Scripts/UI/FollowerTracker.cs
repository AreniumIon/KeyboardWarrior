using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowerTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _followerText = null;

    private void Start()
    {
        GameController.i.playerController.playerResources.changeFollowersEvent += SetText;
    }

    private void SetText(int followerNum)
    {
        _followerText.text = "Followers: " + followerNum.ToString();
    }
}