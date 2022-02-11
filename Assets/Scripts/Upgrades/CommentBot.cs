using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentBot : UpgradeInfo
{
    public override string Name => "Comment Bot";

    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        //GameController.i.playerController.[Give player passive CP]
        base.DoUpgrade();
    }
}
