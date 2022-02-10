using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _chaosPointsText = null;

    private void Start()
    {
        GameController.i.playerController.playerResources.changeChaosPointsEvent += SetText;
    }

    private void SetText(int chaosPoints)
    {
        _chaosPointsText.text = "CP: " + chaosPoints.ToString();
    }
}
