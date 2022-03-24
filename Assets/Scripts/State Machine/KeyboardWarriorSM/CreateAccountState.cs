using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountState : KeyboardWarriorState
{
    public override void Enter()
    {
        ResetAccount();
        GameSceneUIController.i.SetForegroundCanvas(false);
        GameSceneUIController.i.SetCreateAccountCanvas(true);
    }

    public override void Exit()
    {
        GameSceneUIController.i.SetCreateAccountCanvas(false);
    }

    public void ResetAccount()
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;
        //reset account
        // aka, points, reputation, and strikes
        playerResources.CP = 0;
        playerResources.Reputation = 0;
        playerResources.Strikes = 0;

        //reset risk of comments (keep upgrade price?)
        playerResources.TrollRisk = PlayerResources.TrollRiskDefault;
        playerResources.SarcasmRisk = PlayerResources.SarcasmRiskDefault;

        /*
        GameController.i.playerController.playerResources.Followers = 0;
        //do we also keep follower upgrades?
        GameController.i.playerController.playerResources.FollowerCPTime = 2f;
        GameController.i.playerController.playerResources.FollowerCPGain = 1;
        */
        float tempFollowers = GameController.i.playerController.playerResources.Followers;
        tempFollowers *= GameController.i.playerController.playerResources.FollowerKeepPercent;
        Debug.Log("Followers carried over == " + tempFollowers);
        GameController.i.playerController.playerResources.Followers = (int) tempFollowers;
    }
}
