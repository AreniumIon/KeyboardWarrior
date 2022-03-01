using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    public class SampleAchievement : AchievementInfo
    {
        public override string Name => "Sample Achievement";
        public override string Description => "You did it!";

        public override void OnUnlock()
        {

        }
    }

    public class OtherSampleAchievement : AchievementInfo
    {
        public override string Name => "Other Sample Achievement";
        public override string Description => "You did it again!";

        public override void OnUnlock()
        {

        }
    }
}
