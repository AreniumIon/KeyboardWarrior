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
}
