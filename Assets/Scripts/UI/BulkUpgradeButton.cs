using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class BulkUpgradeButton : UpgradeButton
{
    public override void Click()
    {
        PlayerController playerController = GameController.i.playerController;
        PlayerResources playerResources = playerController.playerResources;
        PlayerUpgrades playerUpgrades = playerController.playerUpgrades;

        UpgradeInfo upgradeInfo = playerUpgrades.upgradeInfos[upgradeType];
        int cost = upgradeInfo.GetCost();

        while(playerResources.SpendCP(cost))
        {
            upgradeInfo.DoUpgrade();

            UpdateCostText(upgradeInfo);

            cost = upgradeInfo.GetCost();
        }
    }
}
