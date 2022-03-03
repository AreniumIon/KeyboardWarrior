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
    [SerializeField] public UpgradeType upgradeType;
    [SerializeField] AudioClip buySound;

    public void Start()
    {
        PlayerController playerController = GameController.i.playerController;
        UpgradeInfo upgradeInfo = playerController.playerUpgrades.upgradeInfos[upgradeType];

        UpdateNameText(upgradeInfo);
        UpdateDescriptionText(upgradeInfo);
        UpdateCostText(upgradeInfo);
    }

    public virtual void Click()
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
        OneShotSoundController.PlayClip2D(buySound, 1f);
    }

    private void UpdateNameText(UpgradeInfo upgradeInfo)
    {
        if(nameText != null)
            nameText.text = upgradeInfo.Name;
    }

    private void UpdateDescriptionText(UpgradeInfo upgradeInfo)
    {
        if (descriptionText != null)
            descriptionText.text = upgradeInfo.Description;
    }

    protected void UpdateCostText(UpgradeInfo upgradeInfo)
    {
        if (costText != null)
            costText.text = upgradeInfo.GetCost() + " CP";
    }
}
