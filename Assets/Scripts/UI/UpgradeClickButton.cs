using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class UpgradeClickButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;

    // TODO: Upgrade count should be stored externally. Maybe in PlayerUpgrades?
    int upgrades = 0;

    public void Start()
    {
        UpdateText();
    }

    public void UpgradeClick()
    {
        PlayerController playerController = GameController.i.playerController;
        int cost = UpgradeConstants.GetTestUpgradeCost(upgrades);

        if (playerController.playerResources.SpendChaos(cost))
        {
            upgrades++;
            playerController.playerUpgrades.PointsPerClick += 1;

            UpdateText();
        }
    }

    private void UpdateText()
    {
        costText.text = UpgradeConstants.GetTestUpgradeCost(upgrades) + " CP";
    }
}
