using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class FakeSources : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Fake_Sources;
    public override string Name => "Fake Sources";

    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.CPPerClick += 1;
        base.DoUpgrade();
    }
}
