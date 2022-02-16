using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TODO: Move the reset function to a different script/gameObject

public class WarningButton : MonoBehaviour
{
    [SerializeField] StrikesTracker _strikesTracker;
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _warningText;

    void OnEnable()
    {
        if(GameController.i.playerController.playerResources.Strikes < 3)
        {
            _titleText.text = "Warning";
            _warningText.text = "You just recieved a strike! \nIf you recive a total of 3, your account will be terminated!"+
            "\n\n\n< Click to Continue> ";
        }
        else
        {
            _titleText.text = "ACCOUNT TERMINATED";
            _warningText.text = "You've been banned! Your points are lost with your account. But you keep your upgrades..."+
            "\n\n\n< Click to Continue> ";

            //reset account
            // aka, points, reputation, and strikes
            GameController.i.playerController.playerResources.CP = 0;
            GameController.i.playerController.playerResources.Reputation = 0;
            GameController.i.playerController.playerResources.Strikes = 0;
        }
    }

    public void OnClick()
    {
        //disable self and call strikes tracker to reenable comments
        gameObject.SetActive(false);
        _strikesTracker.OpenWarning(GameController.i.playerController.playerResources.Strikes);
    }
}
