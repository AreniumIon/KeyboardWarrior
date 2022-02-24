using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class SarcasmRisk : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Sarcasm_Risk;
    public override string Name => "Reduce Sarcasm Risk";
    public override string Description => "Reduce risk from sarcastic comments by 3%";

    protected override int BaseCost => 5;

    protected override int ScaleCost => (int)(BaseCost * 1.25);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.SarcasmRisk -= 3f; //warning: this allows for negative risk
        base.DoUpgrade();
    }
}
