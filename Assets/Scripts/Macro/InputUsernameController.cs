using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputUsernameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _inputFieldText;

    public string username;

    private void OnEnable()
    {
        username = "NewUser";
        _inputFieldText.text = username;
    }

    public void StoreUsername(string username)
    {
        this.username = username;
        GameController.i.playerController.Username = username;
    }

}
