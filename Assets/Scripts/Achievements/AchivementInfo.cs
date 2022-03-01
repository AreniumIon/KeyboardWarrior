using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AchievementInfo
{
    //public abstract UpgradeType Type { get; }
    public abstract string Name { get; }
    public abstract string Description { get; }

    public bool unlocked = true;

    // Optional. We can make achievements give the player a permanent bonus on unlocking.
    public virtual void OnUnlock() { }
}
