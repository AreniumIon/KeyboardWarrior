using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class FasterFollowers : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Faster_Followers;
    public override string Name => "Faster Followers";
    public override string Description => "Decrease time between Follower CP gains by 10%";

    protected override int BaseCost => 25;

    protected override int ScaleCost => (int)(BaseCost * 2);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.FollowerCPTime *= 0.9f;
        base.DoUpgrade();
    }
}
