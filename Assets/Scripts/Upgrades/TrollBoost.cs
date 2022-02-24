using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class TrollBoost : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Troll_Boost;
    public override string Name => "Troll Boost";
    public override string Description => "Increase Chaos gained from Trolling";

    protected override int BaseCost => 5;

    protected override int ScaleCost => (int)(BaseCost * 1.5);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.TrollMod += 1f;
        base.DoUpgrade();
    }
}