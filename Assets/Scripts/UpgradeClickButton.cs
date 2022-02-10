using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class UpgradeClickButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;

    int cost = 5;

    public void Start()
    {
        costText.text = cost.ToString() + " CP";
    }

    // TODO: Check if player can afford
    public void UpgradeClick()
    {
        PlayerController playerController = GameController.i.playerController;

        if (playerController.playerResources.SpendChaos(cost))
        {
            playerController.playerUpgrades.PointsPerClick += 1;
        }
    }
}
