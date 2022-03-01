using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class MoreInfluencePerFollower : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.More_Per_Follower;
    public override string Name => "More CP Per Follower";
    public override string Description => "Increase CP per Follower by .05 CP";

    protected override int BaseCost => 15;

    protected override int ScaleCost => (int)(BaseCost * 2);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.FollowerCPGain += 0.05f;
        base.DoUpgrade();
    }
}
