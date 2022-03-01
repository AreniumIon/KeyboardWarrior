using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class FollowerOverReset : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Followers_Over_Reset;
    public override string Name => "Loyal Followers";
    public override string Description => "Increase Followers retained over reset by 10%";

    protected override int BaseCost => 100;

    protected override int ScaleCost => (int)(BaseCost * 4);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.FollowerKeepPercent += 0.1f;
        base.DoUpgrade();
    }
}
