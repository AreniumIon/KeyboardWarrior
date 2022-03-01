using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AchievementConstants;

namespace Achievements
{
    public class SampleAchievement : AchievementInfo
    {
        public override AchievementType Type => AchievementType.Sample_Achievement;
        public override string Name => "Sample Achievement";
        public override string Description => "Have 100 chaos points.";

        public override void OnStart()
        {
            GameController.i.playerController.playerResources.changeCPEvent += CheckUnlock;
        }

        void CheckUnlock(int cp)
        {
            if (cp >= 100)
                OnUnlock();
        }

        // Can also include optional benefit for player, like increased cp per click
        public override void OnUnlock()
        {
            GameController.i.playerController.playerResources.changeCPEvent -= CheckUnlock;
            base.OnUnlock();
        }
    }

    public class OtherSampleAchievement : AchievementInfo
    {
        public override AchievementType Type => AchievementType.Other_Sample_Achievement;
        public override string Name => "Other Sample Achievement";
        public override string Description => "Have 500 chaos points.";

        public override void OnStart()
        {
            GameController.i.playerController.playerResources.changeCPEvent += CheckUnlock;
        }

        void CheckUnlock(int cp)
        {
            if (cp >= 500)
                OnUnlock();
        }

        public override void OnUnlock()
        {
            GameController.i.playerController.playerResources.changeCPEvent -= CheckUnlock;
            base.OnUnlock();
        }
    }
}
