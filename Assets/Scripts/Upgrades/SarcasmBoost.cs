using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class SarcasmBoost : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Sarcasm_Boost;
    public override string Name => "Sarcasm Boost";
    public override string Description => "Increase Chaos gained from Sarcasm";

    protected override int BaseCost => 5;

    protected override int ScaleCost => (int)(BaseCost * 1.5);

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.SarcasmMod += 0.8f; 
        base.DoUpgrade();
    }
}