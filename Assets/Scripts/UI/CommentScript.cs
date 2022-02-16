using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommentScript : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI _buttonText;
    [SerializeField] int buttonType = 0;
    float commentMod = 1f;
    float risk = 0f;
    float riskPercent = 10f;
    float riskReduction = 2f;
    int gainThisTurn = 0;

    private void Start()
    {
        PlayerController playerController = GameController.i.playerController;

        playerController.playerResources.changeCPPerClickEvent += UpdateButton;
        UpdateButton(playerController.playerResources.CPPerClick);
    }

    public void UpdateButton(int pointsPerClick)
    {
        //_buttonText.text = "+" + pointsPerClick + " Chaos";
    }

    public void GainPoints()
    {
        risk = 0;
        commentMod = 1f;

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
            float diceRoll = Random.Range(0f, 100f);
            float totalRisk = risk + GameController.i.playerController.playerResources.Reputation;
            Debug.Log("Diceroll == " + diceRoll + " Total Risk == " + (totalRisk));
            if (diceRoll < totalRisk)
            {
                //divide reputation by 2
                GameController.i.playerController.playerResources.Reputation /= riskReduction;
                // dice rolled lower; punish the player with a strike
                GameController.i.playerController.playerResources.Strikes += 1;
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
