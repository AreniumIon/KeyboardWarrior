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
    [SerializeField] TextMeshProUGUI levelText = null;
    [SerializeField] public UpgradeType upgradeType;
    [SerializeField] public AudioClip buySound;
    [SerializeField] public AudioClip cantBuySound;

    public void Start()
    {
        PlayerController playerController = GameController.i.playerController;
        UpgradeInfo upgradeInfo = playerController.playerUpgrades.upgradeInfos[upgradeType];

        UpdateNameText(upgradeInfo);
        UpdateDescriptionText(upgradeInfo);
        UpdateCostText(upgradeInfo);
        UpdateUpgradeLevel(upgradeInfo);
    }

    public virtual void Click()
    {
        PlayerController playerController = GameController.i.playerController;
        PlayerResources playerResources = playerController.playerResources;
        PlayerUpgrades playerUpgrades = playerController.playerUpgrades;

        UpgradeInfo upgradeInfo = playerUpgrades.upgradeInfos[upgradeType];
        int cost = upgradeInfo.GetCost();

        if(playerResources.CP < cost)
        {
            //play sad sound when player is too poor
            OneShotSoundController.PlayClip2D(cantBuySound, 0.25f);
        }

        if (playerResources.SpendCP(cost))
        {
            upgradeInfo.DoUpgrade();

            UpdateCostText(upgradeInfo);
            UpdateUpgradeLevel(upgradeInfo);

            OneShotSoundController.PlayClip2D(buySound, 1f);
        }
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
            costText.text = upgradeInfo.GetCost() + ""; //+ " CP";
    }

    protected void UpdateUpgradeLevel(UpgradeInfo upgradeInfo)
    {
        if (levelText != null)
            levelText.text = "Lvl: " + upgradeInfo.upgrades;
    }
}
