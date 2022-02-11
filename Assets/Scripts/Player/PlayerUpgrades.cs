using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UpgradeConstants;

public class PlayerUpgrades : MonoBehaviour
{
    public Dictionary<UpgradeType, UpgradeInfo> upgradeInfos = new Dictionary<UpgradeType, UpgradeInfo>()
    {
        { UpgradeType.Comment_Bot, new CommentBot() },
        { UpgradeType.Fake_Sources, new FakeSources() },
        { UpgradeType.Harsh_Vocabulary, new HarshVocabulary() },
    };

    /* Reflection pattern that would eliminate the need for "UpgradeType" enum.
     * Was complicated to read so I chose to use "UpgradeType" instead.
     * Leaving here in case its useful later
    
    public List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>()
    {
        new CommentBot(),
    };

    public UpgradeInfo GetUpgrade<T>() where T : UpgradeInfo
    {
        UpgradeInfo upgradeInfo = upgradeInfos.Find<T, UpgradeInfo>();
        Debug.Assert(upgradeInfo != null, "PlayerUpgrades.Upgrade() called with type not found in upgradeInfos: " + typeof(T).ToString());

        return upgradeInfo;
    }
    */
}
