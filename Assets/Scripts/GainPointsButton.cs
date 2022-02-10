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

        playerController.changePointsPerClickEvent += UpdateButton;
        UpdateButton(playerController.PointsPerClick);
    }

    public void UpdateButton(int pointsPerClick)
    {
        _buttonText.text = "+" + pointsPerClick + " Chaos";
    }

    public void GainPoints()
    {
        GameController.i.playerController.ChaosPoints += GameController.i.playerController.PointsPerClick;
    }
}
