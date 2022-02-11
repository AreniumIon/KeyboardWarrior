using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GainPointsButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _buttonText;

    private void Start()
    {
        PlayerController playerController = GameController.i.playerController;

        playerController.playerResources.changeCPPerClickEvent += UpdateButton;
        UpdateButton(playerController.playerResources.CPPerClick);
    }

    public void UpdateButton(int pointsPerClick)
    {
        _buttonText.text = "+" + pointsPerClick + " Chaos";
    }

    public void GainPoints()
    {
        GameController.i.playerController.playerResources.CP += GameController.i.playerController.playerResources.CPPerClick;
    }
}
