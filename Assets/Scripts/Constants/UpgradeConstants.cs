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
    }
}
