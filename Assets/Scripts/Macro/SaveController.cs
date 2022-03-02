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
        PlayerController pc = GameController.i.playerController;
        PlayerResources pr = pc.playerResources;

        // Resources
        foreach (FieldInfo fieldInfo in pr.GetType().GetFields())
        {
            var value = 0f;
            switch (fieldInfo.GetValue(pr))
            {
                case int i: value = PlayerPrefs.GetInt(fieldInfo.Name, i); break;
                case float f: value = PlayerPrefs.GetFloat(fieldInfo.Name, f); break;
                default:
                    throw new Exception("SaveController.Load attempted to load variable of invalid type from PlayerResources: "
               + fieldInfo.Name + " (typeof " + value.GetType().ToString() + ")");
            }
            fieldInfo.SetValue(pr, value);
            Debug.Log("Set Value: " + fieldInfo.Name + ", " + value);
        }

        // Upgrades
        foreach (UpgradeInfo ui in pc.playerUpgrades.upgradeInfos.Values)
        {
            ui.upgrades = PlayerPrefs.GetInt(ui.Type.ToString());
        }

        // Achievements
        foreach (AchievementInfo ai in pc.playerAchievements.achievementInfos.Values)
        {
            ai.unlocked = PlayerPrefs.GetInt(ai.Type.ToString()) == 1;
        }
    }

    public static void ResetSave()
    {
        // WARNING: This would also delete settings if settings use PlayerPrefs, which might not be what we want
        PlayerPrefs.DeleteAll();
    }
}
