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
    float riskPercent = 20f;
    float riskReduction = 2f;
    int gainThisTurn = 0;

    float sarcasmFollowerGain = 0.01f;
    float trollFollowerGain = 0.05f;

    //profile controller reference
    [SerializeField] ProfileDisplay _profileRoot;

    PlayerController playerController;
    PlayerResources playerResources;

    private void Start()
    {
        playerController = GameController.i.playerController;
        playerResources = playerController.playerResources;

        playerResources.changeReputationEvent += UpdateButton;
        playerResources.changeTrollRiskEvent += UpdateButton;
        playerResources.changeSarcasmRiskEvent += UpdateButton; 
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
                    risk = playerResources.SarcasmRisk; //GameController.i.playerController.playerResources.SarcasmRisk
                    break;

                case 2: // ButtonType 2 == Trolling 
                    risk = playerResources.TrollRisk;
                    break;
            }
            totalRisk = risk + playerResources.Reputation; //repChange

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
                commentMod = playerResources.SarcasmMod;
                risk = playerResources.SarcasmRisk;
                break;

            case 2: // ButtonType 2 == Trolling 
                //Debug.Log("Trolling...");
                commentMod = playerResources.TrollMod;
                risk = playerResources.TrollRisk;
                break;
        }

        //multiply cp gained by type modifier
        gainThisTurn = (int)Mathf.Round(commentMod * playerResources.CPPerClick);
        //Debug.Log("Gain this turn: " + gainThisTurn);

        //add points to player's total
        playerResources.CP += gainThisTurn;

        //add followers to player
        AddFollowers();

        //determine risk of player's comment
        Risk();
    }

    
    void AddFollowers()
    {
        //Debug.Log("Cause you gotta have friends!~");
        int totalCP = playerResources.CP;
        int followerGain = 0;

        if(buttonType == 1)
        {
            //sarcastic follower gain: 5% of current CP
            followerGain += (int)Mathf.Round(totalCP * sarcasmFollowerGain);
        }
        else if(buttonType == 2)
        {
            //troll follower gain: 10% of current CP
            followerGain += (int)Mathf.Round(totalCP * trollFollowerGain);
        }

        //Debug.Log("Followers gained: " + followerGain);
        playerResources.Followers += followerGain;
    }

    void Risk()
    {
        if (buttonType != 0)
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
                playerResources.Strikes += 1;
                GameController.i.keyboardWarriorSM.ChangeState<StrikeState>();
            }
            else
            {
                // dice rolled higher; player is safe but might raise reputation
                // add 1/riskPercent of comment's risk to the reputation
                //roll random risk to add to reputation
                float riskAdd = UnityEngine.Random.Range(1f, riskPercent);
                playerResources.Reputation += (1 / riskAdd);
                Debug.Log("Reputation == " + playerResources.Reputation);
            }
        }
    }
}
