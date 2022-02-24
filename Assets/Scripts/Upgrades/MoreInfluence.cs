using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class MoreInfluence : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.More_Influence;
    public override string Name => "More Influence";
    public override string Description => "Clicks give 1 more Chaos.";

    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.CPPerClick += 1;
        base.DoUpgrade();
    }
}
