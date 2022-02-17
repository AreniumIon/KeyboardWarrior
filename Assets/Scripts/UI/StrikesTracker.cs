using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrikesTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _strikesText = null;

    private void Start()
    {
        GameController.i.playerController.playerResources.changeStrikesEvent += SetText;
    }

    private void SetText(int strikePoints)
    {
        _strikesText.text = "Strikes: " + strikePoints.ToString();
    }
}
