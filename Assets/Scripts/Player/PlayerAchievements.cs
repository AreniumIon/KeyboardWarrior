using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AchievementConstants;
using Achievements;

public class PlayerAchievements : MonoBehaviour
{
    public Dictionary<AchievementType, AchievementInfo> achievementInfos = new Dictionary<AchievementType, AchievementInfo>()
    {
        { AchievementType.Sample_Achievement, new SampleAchievement() },
        { AchievementType.Other_Sample_Achievement, new OtherSampleAchievement() },
    };

    public void SubscribeAchievements()
    {
        foreach (AchievementInfo ai in achievementInfos.Values)
        {
            if (!ai.unlocked)
                ai.SubscribeCheck();
        }
    }
}
