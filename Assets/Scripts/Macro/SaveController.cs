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
        foreach (PropertyInfo propertyInfo in pr.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            var value = propertyInfo.GetValue(pr);
            switch (value)
            {
                case int i: PlayerPrefs.SetInt(propertyInfo.Name, i); break;
                case float f: PlayerPrefs.SetFloat(propertyInfo.Name, f); break;
                default: throw new Exception("SaveController.Save attempted to save variable of invalid type from PlayerResources: "
                    + propertyInfo.Name + " (typeof " + value.GetType().ToString() + ")");
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

        // Save marker
        PlayerPrefs.SetInt("HasSaveData", 1);
    }

    public static void Load()
    {
        PlayerController pc = GameController.i.playerController;
        PlayerResources pr = pc.playerResources;

        // Resources
        foreach (PropertyInfo propertyInfo in pr.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            var value = 0f;
            Debug.Log("Set Value: " + propertyInfo.Name);
            switch (propertyInfo.GetValue(pr))
            {
                case int i: value = PlayerPrefs.GetInt(propertyInfo.Name, i); propertyInfo.SetValue(pr, (int)value); break;
                case float f: value = PlayerPrefs.GetFloat(propertyInfo.Name, f); propertyInfo.SetValue(pr,(float)value); break;
                default:
                    //Debug.LogError("SaveController.Load attempted to load variable of invalid type from PlayerResources: " + propertyInfo.Name + " (typeof " + value.GetType().ToString() + ")");
                    throw new Exception("SaveController.Load attempted to load variable of invalid type from PlayerResources: " + propertyInfo.Name + " (typeof " + value.GetType().ToString() + ")");
            }
            //Debug.Log("Set Value: " + propertyInfo.Name + ", " + value);
            //propertyInfo.SetValue(pr, value);
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
