using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static CommentOutcomeCalc;

public class CommentScript : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI _buttonText;
    [SerializeField] TextMeshProUGUI _riskText = null;
    [SerializeField] ButtonType buttonType = ButtonType.Safe;
    float commentMod = 1f;
    //float risk = 0f;
    //float totalRisk = 0f;
    float riskPercent = 40f; //higher number == lower percent add
    float riskReduction = 2f;
    float riskAddPerButtonPress = 0.5f;
    int gainThisTurn = 0;

    float sarcasmFollowerGain = 0.01f;
    float trollFollowerGain = 0.05f;

    //profile controller reference
    [SerializeField] ProfileDisplay _profileRoot;

    PlayerController playerController;
    PlayerResources playerResources;

    //feedback sounds for clicks
    [SerializeField] AudioClip _clickSound;

    private void Start()
    {
        playerResources = GameController.i.playerController.playerResources;

        switch (buttonType)
        {
            default:
            case ButtonType.Safe:
                break;
            case ButtonType.Sarcastic:
                playerResources.changeSarcasmRiskEvent += UpdateButton;
                GameController.i.keyboardWarriorSM.ChangeStateEvent += (state) => { if (state is MessagesState) UpdateButton(playerResources.SarcasmRisk); };
                UpdateButton(playerResources.SarcasmRisk);
                break;
            case ButtonType.Troll:
                playerResources.changeTrollRiskEvent += UpdateButton;
                GameController.i.keyboardWarriorSM.ChangeStateEvent += (state) => { if (state is MessagesState) UpdateButton(playerResources.TrollRisk); };
                UpdateButton(playerResources.TrollRisk);
                break;
        }
    }

    public void UpdateButton(float risk)
    {
        if (_riskText != null)
            _riskText.text = string.Format("Risk: {0:#.00} % ", risk);
    }
    
    // buttonType
    public static event Action<ButtonType> commentEvent;

    public void Click()
    {
        commentEvent?.Invoke(buttonType);
        OneShotSoundController.PlayClip2D(_clickSound, 1f);
    }

    /*
    
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

                case ButtonType.Sarcastic:
                    risk = playerResources.SarcasmRisk; //GameController.i.playerController.playerResources.SarcasmRisk
                    break;

                case ButtonType.Troll:
                    risk = playerResources.TrollRisk;
                    break;
            }
            totalRisk = risk + playerResources.Reputation; //repChange

            _riskText.text = string.Format("Risk: {0:#.00} % ", totalRisk);
        }
    }

    private void GainPoints()
    {
        //change modifier value based on button type
        switch (buttonType)
        {
            default:// ButtonType Default: Normal 
                //Debug.Log("Generating Normal Comment...");
                break;

            case ButtonType.Sarcastic:
                //Debug.Log("Deploying Sarcasm...");
                commentMod = playerResources.SarcasmMod;
                risk = playerResources.SarcasmRisk;
                break;

            case ButtonType.Troll:
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

        if(buttonType == ButtonType.Sarcastic)
        {
            //sarcastic follower gain: 5% of current CP
            followerGain += (int)Mathf.Round(totalCP * sarcasmFollowerGain);
        }
        else if(buttonType == ButtonType.Troll)
        {
            //troll follower gain: 10% of current CP
            followerGain += (int)Mathf.Round(totalCP * trollFollowerGain);
        }

        //Debug.Log("Followers gained: " + followerGain);
        playerResources.Followers += followerGain;
    }

    void Risk()
    {
        if (buttonType != ButtonType.Safe)
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

                //increase button risk by an amount
                if (buttonType == ButtonType.Sarcastic)
                    playerResources.SarcasmRisk += riskAddPerButtonPress;
                else
                    playerResources.TrollRisk += riskAddPerButtonPress;
            }
        }
    }
    */
}
