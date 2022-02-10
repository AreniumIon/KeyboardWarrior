using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentBot : UpgradeInfo
{
    protected override int BaseCost => 5;

    protected override int ScaleCost => 10;

    public override void DoUpgrade()
    {
        //GameController.i.playerController.[Give player passive CP]
    }
}
