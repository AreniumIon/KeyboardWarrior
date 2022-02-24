﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountState : KeyboardWarriorState
{
    public override void Enter()
    {
        ResetAccount();
        GameController.i.uiController.SetForegroundCanvas(false);
        GameController.i.uiController.SetCreateAccountCanvas(true);
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        GameController.i.uiController.SetCreateAccountCanvas(false);
    }

    public void ResetAccount()
    {
        //reset account
        // aka, points, reputation, and strikes
        GameController.i.playerController.playerResources.CP = 0;
        GameController.i.playerController.playerResources.Reputation = 0;
        GameController.i.playerController.playerResources.Strikes = 0;
        //TODO: consider upgrade to keep percentage of followers
        GameController.i.playerController.playerResources.Followers = 0;
        GameController.i.playerController.playerResources.FollowerCPTime = 2f;
        GameController.i.playerController.playerResources.FollowerCPGain = 1;
    }
}