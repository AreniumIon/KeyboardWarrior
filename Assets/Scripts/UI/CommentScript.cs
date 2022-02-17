using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CommentScript : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI _buttonText;
    [SerializeField] TextMeshProUGUI _riskText = null;
    [SerializeField] int buttonType = 0;
    float commentMod = 1f;
    float risk = 0f;
    float totalRisk = 0f;
    float riskPercent = 10f;
    float riskReduction = 2f;
    int gainThisTurn = 0;

    //profile controller reference
    [SerializeField] ProfileDisplay _profileRoot;

    private void Start()
    {
        PlayerController playerController = GameController.i.playerController;

        playerController.playerResources.changeReputationEvent += UpdateButton;
        UpdateButton(playerController.playerResources.CPPerClick);
    }

    public void UpdateButton(float repChange)
    {
        //_buttonText.text = "+" + pointsPerClick + " Chaos";
        if (_riskText != null)
        {
            //change modifier value based on button type
            switch (buttonType)
            {
                default:// ButtonType Default: Normal 
                    break;

                case 1:// ButtonType 2 == Sarcasm
                    risk = GameController.i.playerController.playerResources.SarcasmRisk;
                    break;

                case 2: // ButtonType 2 == Trolling 
                    risk = GameController.i.playerController.playerResources.TrollRisk;
                    break;
            }
            totalRisk = risk + GameController.i.playerController.playerResources.Reputation; //repChange

            _riskText.text = string.Format("Risk: {0:#.00} % ", totalRisk);
        }
    }

    public static event Action commentEvent;

    public void Click()
    {
        GainPoints();
        commentEvent?.Invoke();
        _profileRoot.AssignNewProfile();
    }

    private void GainPoints()
    {
        //change modifier value based on button type
        switch (buttonType)
        {
            default:// ButtonType Default: Normal 
                //Debug.Log("Generating Normal Comment...");
                break;

            case 1:// ButtonType 2 == Sarcasm
                //Debug.Log("Deploying Sarcasm...");
                commentMod = GameController.i.playerController.playerResources.SarcasmMod;
                risk = GameController.i.playerController.playerResources.SarcasmRisk;
                break;

            case 2: // ButtonType 2 == Trolling 
                //Debug.Log("Trolling...");
                commentMod = GameController.i.playerController.playerResources.TrollMod;
                risk = GameController.i.playerController.playerResources.TrollRisk;
                break;
        }

        //multiply cp gained by type modifier
        gainThisTurn = (int)Mathf.Round(commentMod * GameController.i.playerController.playerResources.CPPerClick);
        //Debug.Log("Gain this turn: " + gainThisTurn);

        //add points to player's total
        GameController.i.playerController.playerResources.CP += gainThisTurn;

        if (risk > 0)
        {
            //determine if player is striked for comment
            float diceRoll = UnityEngine.Random.Range(0f, 100f);
            totalRisk = risk + GameController.i.playerController.playerResources.Reputation;
            Debug.Log("Diceroll == " + diceRoll + " Total Risk == " + (totalRisk));
            if (diceRoll < totalRisk)
            {
                //divide reputation by 2
                GameController.i.playerController.playerResources.Reputation /= riskReduction;
                // dice rolled lower; punish the player with a strike
                GameController.i.playerController.playerResources.Strikes += 1;
                GameController.i.keyboardWarriorSM.ChangeState<StrikeState>();
            }
            else
            {
                // dice rolled higher; player is safe but might raise reputation
                // add 1/riskPercent of comment's risk to the reputation
                GameController.i.playerController.playerResources.Reputation += (risk / riskPercent);
                Debug.Log("Reputation == " + GameController.i.playerController.playerResources.Reputation);
            }
        }
    }
}
