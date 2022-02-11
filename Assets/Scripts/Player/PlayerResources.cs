using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerResources : MonoBehaviour
{
    int cp = 0;
    public int CP { get => cp; set { cp = value; changeCPEvent?.Invoke(cp); } }
    public event Action<int> changeCPEvent;

    public bool SpendCP(int amount)
    {
        if (cp < amount)
            return false;

        CP -= amount;
        return true;
    }

    int cpPerClick = 1;
    public int CPPerClick { get => cpPerClick; set { cpPerClick = value; changeCPPerClickEvent?.Invoke(cpPerClick); } }
    public event Action<int> changeCPPerClickEvent;

    int cpPerSecond = 0;
    public int CPPerSecond { get => cpPerSecond; set { cpPerSecond = value; changeCPPerSecondEvent?.Invoke(cpPerSecond); } }
    public event Action<int> changeCPPerSecondEvent;

    // TODO: Followers, experts, flags
}
