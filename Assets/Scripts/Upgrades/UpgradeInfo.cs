using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

public abstract class UpgradeInfo
{
    public abstract UpgradeType Type { get; }
    public abstract string Name { get; }
    public abstract string Description { get; }

    public bool unlocked = true;

    // Should upgrades be one-time purchases or multiple times?
    // Maybe we do both, in which case I'd make two child classes
    public int upgrades = 0;

    protected abstract int BaseCost { get; }
    protected abstract int ScaleCost { get; }

    public int GetCost()
    {
        return BaseCost + ScaleCost * upgrades;
    }

    public virtual void DoUpgrade() { upgrades += 1; }
}
