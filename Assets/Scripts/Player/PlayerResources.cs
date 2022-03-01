using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerResources : MonoBehaviour
{
    int cp = 0;
    public int CP { get => cp; set { cp = value; changeCPEvent?.Invoke(cp); } }
    public event Action<int> changeCPEvent;

    int strikes = 0;
    public int Strikes { get => strikes; set { strikes = value; changeStrikesEvent?.Invoke(strikes); } }
    public event Action<int> changeStrikesEvent;

    float reputation = 0;
    public float Reputation { get => reputation; set { reputation = value; changeReputationEvent?.Invoke(reputation); } }
    public event Action<float> changeReputationEvent;

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

    //comment type modifiers
    
    float trollMod = 2f;
    public float TrollMod { get => trollMod; set { trollMod = value; changeTrollModEvent?.Invoke(trollMod); } }
    public event Action<float> changeTrollModEvent;

    float sarcasmMod = 1.5f;
    public float SarcasmMod { get => sarcasmMod; set { sarcasmMod = value; changeSarcasmModEvent?.Invoke(sarcasmMod); } }
    public event Action<float> changeSarcasmModEvent;

    // comment risk modifiers

    public static float TrollRiskDefault = 10f;
    float trollRisk = TrollRiskDefault;
    public float TrollRisk { get => trollRisk; set { trollRisk = value; changeTrollRiskEvent?.Invoke(trollRisk); } }
    public event Action<float> changeTrollRiskEvent;

    public bool LowerTrollRisk(float amount)
    {
        if (trollRisk <= 0)
            return false;

        if (trollRisk - amount <= 0)
            TrollRisk = 0;
        else
            TrollRisk -= amount;
        
        return true;
    }

    public static float SarcasmRiskDefault = 2f;
    float sarcasmRisk = SarcasmRiskDefault;
    public float SarcasmRisk { get => sarcasmRisk; set { sarcasmRisk = value; changeSarcasmRiskEvent?.Invoke(sarcasmRisk); } }
    public event Action<float> changeSarcasmRiskEvent;

    public bool LowerSarcasmRisk(float amount)
    {
        if (sarcasmRisk <= 0)
            return false;

        if (sarcasmRisk - amount <= 0)
            SarcasmRisk = 0;
        else
            SarcasmRisk -= amount;

        return true;
    }


    // followers

    int followers = 0;
    public int Followers { get => followers; set { followers = value; changeFollowersEvent?.Invoke(followers); } }
    public event Action<int> changeFollowersEvent;

    float followerCPTime = 2f;
    public float FollowerCPTime { get => followerCPTime; set { followerCPTime = value; changeFollowerCPTimeEvent?.Invoke(followerCPTime); } }
    public event Action<float> changeFollowerCPTimeEvent;

    float followerCPGain = 0.30f;
    public float FollowerCPGain { get => followerCPGain; set { followerCPGain = value; changeFollowerCPGainEvent?.Invoke(followerCPGain); } }
    public event Action<float> changeFollowerCPGainEvent;

    float followerKeepPercent = 0f;
    public float FollowerKeepPercent { get => followerKeepPercent; set { followerKeepPercent = value; changeFollowerKeepPercentEvent?.Invoke(followerKeepPercent); } }
    public event Action<float> changeFollowerKeepPercentEvent;

    // TODO: Followers, experts, flags

}
