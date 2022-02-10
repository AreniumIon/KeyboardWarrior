using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerResources : MonoBehaviour
{
    int chaosPoints = 0;
    public int ChaosPoints { get => chaosPoints; set { chaosPoints = value; changeChaosPointsEvent?.Invoke(chaosPoints); } }
    public event Action<int> changeChaosPointsEvent;

    public bool SpendChaos(int amount)
    {
        if (chaosPoints < amount)
            return false;

        ChaosPoints -= amount;
        return true;
    }

    // TODO: Followers, experts, flags
}
