using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUpgrades : MonoBehaviour
{
    int pointsPerClick = 1;
    public int PointsPerClick { get => pointsPerClick; set { pointsPerClick = value; changePointsPerClickEvent?.Invoke(pointsPerClick); } }
    public event Action<int> changePointsPerClickEvent;


    // TODO: Store individual times each upgrade has been bought

    public List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>();


    public void UnlockUpgrade<T>() where T : UpgradeInfo
    {
        UpgradeInfo upgradeInfo = upgradeInfos.Find<T, UpgradeInfo>();
        Debug.Assert(upgradeInfo != null, "PlayerUpgrades.UnlockUpgrade() called with type not found in upgradeInfos: " + typeof(T).ToString());

        upgradeInfo.unlocked = true;
    }

    public void Upgrade<T>() where T : UpgradeInfo
    {
        UpgradeInfo upgradeInfo = upgradeInfos.Find<T, UpgradeInfo>();
        Debug.Assert(upgradeInfo != null, "PlayerUpgrades.UnlockUpgrade() called with type not found in upgradeInfos: " + typeof(T).ToString());

        upgradeInfo.DoUpgrade();
    }
}
