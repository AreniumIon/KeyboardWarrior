using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UpgradeConstants;

namespace Upgrades {

    public class MoreInfluence : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.More_Influence;
        public override string Name => "More Influence";
        public override string Description => "Clicks give 1 more Chaos.";

        protected override int BaseCost => 5;

        protected override int ScaleCost => 10;

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.CPPerClick += 1;
            base.DoUpgrade();
        }
    }

    //----------------------Sarcasm Upgrades

    public class SarcasmRisk : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Sarcasm_Risk;
        public override string Name => "Reduce Sarcasm Risk";
        public override string Description => "Reduce risk from sarcastic comments by 50%";

        protected override int BaseCost => 5;

        protected override int ScaleCost => (int)(BaseCost * 1.5);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.SarcasmRisk *= 0.5f;
            base.DoUpgrade();
        }
    }

    public class SarcasmBoost : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Sarcasm_Boost;
        public override string Name => "Sarcasm Boost";
        public override string Description => "Increase Chaos gained from Sarcasm";

        protected override int BaseCost => 5;

        protected override int ScaleCost => (int)(BaseCost * 1.5);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.SarcasmMod += 0.8f;
            base.DoUpgrade();
        }
    }

    //----------------------Troll Upgrades

    public class TrollRisk : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Troll_Risk;
        public override string Name => "Reduce Troll Risk";
        public override string Description => "Reduce risk from Troll comments by 50%";

        protected override int BaseCost => 5;

        protected override int ScaleCost => (int)(BaseCost * 1.5);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.TrollRisk *= 0.5f;
            base.DoUpgrade();
        }
    }

    public class TrollBoost : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Troll_Boost;
        public override string Name => "Troll Boost";
        public override string Description => "Increase Chaos gained from Trolling";

        protected override int BaseCost => 5;

        protected override int ScaleCost => (int)(BaseCost * 1.5);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.TrollMod += 1f;
            base.DoUpgrade();
        }
    }

    //---------------Follower Upgrades

    public class FasterFollowers : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Faster_Followers;
        public override string Name => "Faster Followers";
        public override string Description => "Decrease time between Follower CP gains by 10%";

        protected override int BaseCost => 25;

        protected override int ScaleCost => (int)(BaseCost * 2);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.FollowerCPTime *= 0.9f;
            base.DoUpgrade();
        }
    }

    public class MoreInfluencePerFollower : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.More_Per_Follower;
        public override string Name => "More CP Per Follower";
        public override string Description => "Increase CP per Follower by .05 CP";

        protected override int BaseCost => 15;

        protected override int ScaleCost => (int)(BaseCost * 2);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.FollowerCPGain += 0.05f;
            base.DoUpgrade();
        }
    }

    public class FollowerOverReset : UpgradeInfo
    {
        public override UpgradeType Type => UpgradeType.Followers_Over_Reset;
        public override string Name => "Loyal Followers";
        public override string Description => "Increase Followers retained over reset by 10%";

        protected override int BaseCost => 100;

        protected override int ScaleCost => (int)(BaseCost * 4);

        public override void DoUpgrade()
        {
            GameController.i.playerController.playerResources.FollowerKeepPercent += 0.1f;
            base.DoUpgrade();
        }
    }
}
