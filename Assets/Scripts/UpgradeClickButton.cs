using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClickButton : MonoBehaviour
{
    // TODO: Check if player can afford
    public void UpgradeClick()
    {
        GameController.i.playerController.PointsPerClick += 1;
    }
}
