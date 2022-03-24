using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _chaosPointsText = null;

    private void Start()
    {
        PlayerResources pr = GameController.i.playerController.playerResources;

        pr.changeCPEvent += SetText;
        SetText(pr.CP);
    }

    private void SetText(int chaosPoints)
    {
        //_chaosPointsText.text = "Chaos: " + chaosPoints.ToString();
        _chaosPointsText.text = ": " + chaosPoints.ToString();
    }
}
