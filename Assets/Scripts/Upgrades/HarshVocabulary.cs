using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class HarshVocabulary : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Harsh_Vocabulary;
    public override string Name => "Harsh Vocabulary";

    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.CPPerClick += 1;
        base.DoUpgrade();
    }
}
