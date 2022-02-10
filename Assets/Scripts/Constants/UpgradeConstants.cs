using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradeConstants
{
    // Simple cost scaling demonstration.
    public static int TEST_UPGRADE_BASE_COST = 5;
    public static int TEST_UPGRADE_SCALE_COST = 10;

    public static int GetTestUpgradeCost(int timesUpgraded)
    {
        return TEST_UPGRADE_BASE_COST + TEST_UPGRADE_SCALE_COST * timesUpgraded;
    }

    // Possible sorting structure for upgrades.
    // PlayerUpgrades would store Dictionary<UpgradeType, int> with the int being how many times its upgraded
    public enum UpgradeType
    { 
        Comment_Bot, // Gives 1 CP per second per ugprade
        Fake_Sources, // +1 CP for tame responses per upgrade
        Harsh_Vocabulary, // +3 CP for risky responses per upgrade
    }
}
