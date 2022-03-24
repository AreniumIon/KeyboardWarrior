using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrikesTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _strikesText = null;

    private void Start()
    {
        PlayerResources pr = GameController.i.playerController.playerResources;

        pr.changeStrikesEvent += SetText;
        SetText(pr.Strikes);
    }

    private void SetText(int strikePoints)
    {
        _strikesText.text = ": " + strikePoints.ToString();
    }
}
