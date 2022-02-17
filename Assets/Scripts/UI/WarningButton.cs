using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _warningText;

    void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (GameController.i.playerController.playerResources.Strikes < 3)
        {
            _titleText.text = "Warning";
            _warningText.text = "You just recieved a strike! \nIf you recive a total of 3, your account will be terminated!" +
            "\n\n\n< Click to Continue> ";
        }
        else
        {
            _titleText.text = "ACCOUNT TERMINATED";
            _warningText.text = "You've been banned! Your points are lost with your account. But you keep your upgrades..." +
            "\n\n\n< Click to Continue> ";
        }
    }

    public void OnClick()
    {
        if (GameController.i.playerController.playerResources.Strikes < 3)
        {
            GameController.i.keyboardWarriorSM.ChangeState<MessagesState>();
        }
        else
        {
            GameController.i.keyboardWarriorSM.ChangeState<CreateAccountState>();
        }
    }
}
