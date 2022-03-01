using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AchievementInfo
{
    //public abstract UpgradeType Type { get; }
    public abstract string Name { get; }
    public abstract string Description { get; }

    public bool unlocked = true;

    // Subscribe to events for unlocking. Called in PlayerAchievements.
    public virtual void OnStart() { }

    public virtual void OnUnlock()
    {
        // TODO: Notifications
        // Notifications.NotifyAchievement(this);
    }
}
