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

        playerController.playerUpgrades.changePointsPerClickEvent += UpdateButton;
        UpdateButton(playerController.playerUpgrades.PointsPerClick);
    }

    public void UpdateButton(int pointsPerClick)
    {
        _buttonText.text = "+" + pointsPerClick + " Chaos";
    }

    public void GainPoints()
    {
        GameController.i.playerController.playerResources.ChaosPoints += GameController.i.playerController.playerUpgrades.PointsPerClick;
    }
}
