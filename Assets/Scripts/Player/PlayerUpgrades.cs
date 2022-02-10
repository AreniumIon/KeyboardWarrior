using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUpgrades : MonoBehaviour
{
    int pointsPerClick = 1;
    public int PointsPerClick { get => pointsPerClick; set { pointsPerClick = value; changePointsPerClickEvent?.Invoke(pointsPerClick); } }
    public event Action<int> changePointsPerClickEvent;


    // TODO: Store individual times each upgrade has been bought
}
