﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // This could be display on the user's troll twitter account or something.
    public string username = "DefaultUsername";

    int chaosPoints = 0;
    public int ChaosPoints { get => chaosPoints; set { chaosPoints = value; changeChaosPointsEvent?.Invoke(chaosPoints); } }
    public event Action<int> changeChaosPointsEvent;

    int pointsPerClick = 1;
    public int PointsPerClick { get => pointsPerClick; set { pointsPerClick = value; changePointsPerClickEvent?.Invoke(pointsPerClick); } }
    public event Action<int> changePointsPerClickEvent;

}
