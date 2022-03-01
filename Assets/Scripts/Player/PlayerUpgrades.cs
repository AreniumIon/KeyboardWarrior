using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UpgradeConstants;

public class PlayerUpgrades : MonoBehaviour
{
    public Dictionary<UpgradeType, UpgradeInfo> upgradeInfos = new Dictionary<UpgradeType, UpgradeInfo>()
    {
        { UpgradeType.Comment_Bot,              new CommentBot() },
        { UpgradeType.Fake_Sources,             new FakeSources() },
        { UpgradeType.Harsh_Vocabulary,         new HarshVocabulary() },
        { UpgradeType.More_Influence,           new Upgrades.MoreInfluence() },
        { UpgradeType.Sarcasm_Risk,             new Upgrades.SarcasmRisk() },
        { UpgradeType.Troll_Risk,               new Upgrades.TrollRisk() },
        { UpgradeType.Sarcasm_Boost,            new Upgrades.SarcasmBoost() },
        { UpgradeType.Troll_Boost,              new Upgrades.TrollBoost() },
        { UpgradeType.Faster_Followers,         new Upgrades.FasterFollowers() },
        { UpgradeType.More_Per_Follower,        new Upgrades.MoreInfluencePerFollower() },
        { UpgradeType.Followers_Over_Reset,     new Upgrades.FollowerOverReset() },
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
