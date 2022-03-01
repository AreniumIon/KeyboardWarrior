using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class SaveController
{
    public static void Save()
    {
        PlayerController pc = GameController.i.playerController;
        PlayerResources pr = pc.playerResources;

        // Resources

        // Manually setting every variable is annoying so I'm using reflection instead
        // PlayerPrefs.SetInt("CP", pc.playerResources.CP);
        // PlayerPrefs.SetInt("Strikes", pc.playerResources.Strikes);
        // PlayerPrefs.SetFloat("Reputation", pc.playerResources.Reputation);

        foreach (FieldInfo fieldInfo in pr.GetType().GetFields())
        {
            var value = fieldInfo.GetValue(pr);
            switch (value)
            {
                case int i: PlayerPrefs.SetInt(fieldInfo.Name, i); break;
                case float f: PlayerPrefs.SetFloat(fieldInfo.Name, f); break;
                default: throw new Exception("SaveController.Save attempted to save variable of invalid type from PlayerResources: "
                    + fieldInfo.Name + " (typeof " + value.GetType().ToString() + ")");
            }
        }

        // Upgrades
        foreach (UpgradeInfo ui in pc.playerUpgrades.upgradeInfos.Values)
        {
            PlayerPrefs.SetInt(ui.Type.ToString(), ui.upgrades);
        }

        // Achievements
        foreach (AchievementInfo ai in pc.playerAchievements.achievementInfos.Values)
        {
            PlayerPrefs.SetInt(ai.Type.ToString(), ai.unlocked ? 1 : 0);
        }
    }

    public static void Load()
    {

    }
}
