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

    float trollRisk = 10f;
    public float TrollRisk { get => trollRisk; set { trollRisk = value; changeTrollRiskEvent?.Invoke(trollRisk); } }
    public event Action<float> changeTrollRiskEvent;

    float sarcasmRisk = 2f;
    public float SarcasmRisk { get => sarcasmRisk; set { sarcasmRisk = value; changeSarcasmRiskEvent?.Invoke(sarcasmRisk); } }
    public event Action<float> changeSarcasmRiskEvent;

    // TODO: Followers, experts, flags
}
