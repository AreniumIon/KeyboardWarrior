using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AchievementConstants;

public abstract class AchievementInfo
{
    public abstract AchievementType Type { get; }
    public abstract string Name { get; }
    public abstract string Description { get; }

    public bool unlocked = true;

    // Subscribe to events for unlocking. Called in PlayerAchievements.
    public virtual void SubscribeCheck() { }

    public virtual void OnUnlock()
    {
        // TODO: Notifications
        // Notifications.NotifyAchievement(this);

        Debug.Log("Achievement Unlocked: " + Name);
    }
}
