using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public class CommentBot : UpgradeInfo
{
    public override UpgradeType Type => UpgradeType.Comment_Bot;
    public override string Name => "Comment Bot";
    public override string Description => "Clicks give 1 more Chaos.";

    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        GameController.i.playerController.playerResources.CPPerClick += 1;
        //GameController.i.playerController.playerResources.CPPerSecond += 1;
        base.DoUpgrade();
    }
}
