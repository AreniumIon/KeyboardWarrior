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

    //feedback sounds for clicks
    [SerializeField] AudioClip _clickSound;

    private void Start()
    {
        PlayerResources playerResources = GameController.i.playerController.playerResources;

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

}
