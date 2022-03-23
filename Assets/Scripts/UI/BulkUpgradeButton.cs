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

        if (playerResources.CP < cost)
        {
            //play sad sound when player is too poor
            OneShotSoundController.PlayClip2D(cantBuySound, 0.25f);
        }

        int timesUpgraded = 0;

        while (playerResources.SpendCP(cost))
        {
            if(timesUpgraded < 1)
            {
                //play sound if can buy at least one upgrade
                OneShotSoundController.PlayClip2D(buySound, 1.5f);
            }
            timesUpgraded++;

            upgradeInfo.DoUpgrade();

            UpdateCostText(upgradeInfo);
            UpdateUpgradeLevel(upgradeInfo);

            cost = upgradeInfo.GetCost(); 
        }
    }
}
