using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeConstants
{
    public enum UpgradeType
    { 
        Comment_Bot, // Gives 1 CP per second per ugprade
        Fake_Sources, // +1 CP for tame responses per upgrade
        Harsh_Vocabulary, // +3 CP for risky responses per upgrade
        More_Influence, //+1 CP gain
        Sarcasm_Risk, //reduce sarcasm risk by 3%
        Troll_Risk, //reduce troll risk by 2%
        Sarcasm_Boost, //increase mod from sarcasm by 0.8
        Troll_Boost, //increase mod from trolling by 1
    }
}
