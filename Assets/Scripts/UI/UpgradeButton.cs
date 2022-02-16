using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using static UpgradeConstants;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI descriptionText = null;
    [SerializeField] TextMeshProUGUI costText = null;
    [SerializeField] UpgradeType upgradeType;

    public void Start()
    {
        PlayerController playerController = GameController.i.playerController;
        UpgradeInfo upgradeInfo = playerController.playerUpgrades.upgradeInfos[upgradeType];

        UpdateNameText(upgradeInfo);
        UpdateDescriptionText(upgradeInfo);
        UpdateCostText(upgradeInfo);
    }

    public void Click()
    {
        PlayerController playerController = GameController.i.playerController;
        PlayerResources playerResources = playerController.playerResources;
        PlayerUpgrades playerUpgrades = playerController.playerUpgrades;

        UpgradeInfo upgradeInfo = playerUpgrades.upgradeInfos[upgradeType];
        int cost = upgradeInfo.GetCost();

        if (playerResources.SpendCP(cost))
        {
            upgradeInfo.DoUpgrade();

            UpdateCostText(upgradeInfo);
        }
    }

    private void UpdateNameText(UpgradeInfo upgradeInfo)
    {
        nameText.text = upgradeInfo.Name;
    }

    private void UpdateDescriptionText(UpgradeInfo upgradeInfo)
    {
        descriptionText.text = upgradeInfo.Description;
    }

    private void UpdateCostText(UpgradeInfo upgradeInfo)
    {
        costText.text = upgradeInfo.GetCost() + " CP";
    }
}
