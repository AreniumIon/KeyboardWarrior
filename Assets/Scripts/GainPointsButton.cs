using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPointsButton : MonoBehaviour
{
    [SerializeField] int _pointsOnClick = 1;

    public void GainPoints()
    {
        GameController.i.playerController.ChaosPoints += _pointsOnClick;
    }
}
