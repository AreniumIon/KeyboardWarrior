using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class TrollRisk : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Troll_Risk;
    public override string Name => "Reduce Troll Risk";
    public override string Description => "Reduce risk from Troll comments by 50%";

    protected override int BaseCost => 5;

    protected override int ScaleCost => (int)(BaseCost * 1.5);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.TrollRisk *= 0.5f;
        base.DoUpgrade();
    }
}
