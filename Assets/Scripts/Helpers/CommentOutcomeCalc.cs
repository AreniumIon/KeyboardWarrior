using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CommentOutcomeCalc
{
    public enum ButtonType
    {
        Safe,
        Sarcastic,
        Troll,
    }

    static float SARCASM_FOLLOWER_GAIN = 0.01f;
    static float TROLL_FOLLOWER_GAIN = 0.05f;
    static float RISK_PERCENT = 40f;
    static float RISK_ADD_PER_BUTTON_PRESS = 0.5f;
    static float RISK_REDUCTION = 2f;


    public static bool RollSuccess(ButtonType buttonType)
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

        if (buttonType == ButtonType.Safe)
            return true;

        //determine if player is striked for comment
        float diceRoll = UnityEngine.Random.Range(0f, 100f);
        float risk = (buttonType == ButtonType.Sarcastic) ? playerResources.SarcasmRisk : playerResources.TrollRisk;

        Debug.Log("Diceroll == " + diceRoll + " Total Risk == " + (risk));
        return diceRoll >= risk;
    }

    public static void OnSuccess(ButtonType buttonType)
    {
        GainPoints(buttonType);
        AddFollowers(buttonType);
        GainRisk(buttonType);
    }

    private static void GainPoints(ButtonType buttonType)
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

        float commentMod;

        switch (buttonType)
        {
            default:
            case ButtonType.Safe: commentMod = playerResources.SafeMod; break;
            case ButtonType.Sarcastic: commentMod = playerResources.SarcasmMod; break;
            case ButtonType.Troll: commentMod = playerResources.TrollMod; break;
        }

        //multiply cp gained by type modifier
        int gainThisTurn = Mathf.RoundToInt(commentMod * playerResources.CPPerClick);

        //add points to player's total
        playerResources.CP += gainThisTurn;
    }

    private static void AddFollowers(ButtonType buttonType)
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

        int totalCP = playerResources.CP;
        int followerGain = 0;

        switch (buttonType)
        {
            default:
            case ButtonType.Safe: break;
            case ButtonType.Sarcastic: followerGain += (int)Mathf.Round(totalCP * SARCASM_FOLLOWER_GAIN); break;
            case ButtonType.Troll: followerGain += (int)Mathf.Round(totalCP * TROLL_FOLLOWER_GAIN); break;
        }

        playerResources.Followers += followerGain;
    }

    private static void GainRisk(ButtonType buttonType)
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

        // No risk for safe comments
        if (buttonType == ButtonType.Safe)
            return;

        // dice rolled higher; player is safe but might raise reputation
        // add 1/riskPercent of comment's risk to the reputation
        //roll random risk to add to reputation
        float riskAdd = UnityEngine.Random.Range(1f, RISK_PERCENT);
        playerResources.Reputation += (1 / riskAdd);
        Debug.Log("Reputation == " + playerResources.Reputation);

        //increase button risk by an amount
        playerResources.SarcasmRisk += RISK_ADD_PER_BUTTON_PRESS + playerResources.Reputation;
        playerResources.TrollRisk += RISK_ADD_PER_BUTTON_PRESS + playerResources.Reputation;
    }


    public static void OnStrike(ButtonType buttonType)
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

        //divide reputation by 2
        playerResources.Reputation /= RISK_REDUCTION;
        // dice rolled lower; punish the player with a strike
        playerResources.Strikes += 1;
        GameController.i.keyboardWarriorSM.ChangeState<StrikeState>();
    }
}
