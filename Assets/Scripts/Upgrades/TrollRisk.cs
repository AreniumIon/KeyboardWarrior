using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class TrollRisk : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Troll_Risk;
    public override string Name => "Reduce Troll Risk";
    public override string Description => "Reduce risk from Troll comments by 2%";

    protected override int BaseCost => 5;

    protected override int ScaleCost => (int)(BaseCost * 1.25);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.TrollRisk -= 2f; //warning: this allows for negative risk
        base.DoUpgrade();
    }
}
