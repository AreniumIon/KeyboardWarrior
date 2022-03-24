using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgressController : MonoBehaviour
{
    [SerializeField] GameObject _resetProgressPanel;

    private void OnEnable()
    {
        _resetProgressPanel.SetActive(false);
    }

    public void ClickResetData()
    {
        _resetProgressPanel.SetActive(true);
    }

    public void CancelResetData()
    {
        _resetProgressPanel.SetActive(false);
    }

    public void ConfirmResetData()
    {
        SaveController.ResetSave();
        _resetProgressPanel.SetActive(false);
        GameController.i.keyboardWarriorSM.ChangeState<CreateAccountState>();
    }
}
