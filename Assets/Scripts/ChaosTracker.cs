using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _chaosPointsText;

    int chaosPoints = 0;

    public void GainChaosPoints(int points)
    {
        chaosPoints += points;
        SetText();
    }

    private void SetText()
    {
        _chaosPointsText.text = "Chaos Points: " + chaosPoints.ToString();
    }
}
