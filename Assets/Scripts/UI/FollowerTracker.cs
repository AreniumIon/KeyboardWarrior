using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowerTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _followerText = null;

    private void Start()
    {
        PlayerResources pr = GameController.i.playerController.playerResources;

        pr.changeFollowersEvent += SetText;
        SetText(pr.Followers);
    }

    private void SetText(int followerNum)
    {
        //_followerText.text = "Followers: " + followerNum.ToString();
        _followerText.text = ": " + followerNum.ToString();
    }
}