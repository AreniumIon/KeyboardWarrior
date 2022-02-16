using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrikesTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _strikesText = null;
    [SerializeField] GameObject _commentGroup = null;
    [SerializeField] GameObject _warningButton = null;

    private void Start()
    {
        GameController.i.playerController.playerResources.changeStrikesEvent += SetText;

        PlayerController playerController = GameController.i.playerController;
        playerController.playerResources.changeStrikesEvent += OpenWarning;
        if (_warningButton != null)
            _warningButton.SetActive(false);
    }

    public void OpenWarning(int strikePoints)
    {
        //open/close warning button and comment group
        if (_commentGroup != null && _warningButton != null) {
            if (_commentGroup.activeSelf)
            {
                _warningButton.SetActive(true);
                _commentGroup.SetActive(false);
            }
            else
            {
                _warningButton.SetActive(false);
                _commentGroup.SetActive(true);
            }
        }
    }

    private void SetText(int strikePoints)
    {
        _strikesText.text = "Strikes: " + strikePoints.ToString();
    }
}
