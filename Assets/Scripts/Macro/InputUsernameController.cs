using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputUsernameController : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputField;

    public string username;

    private void OnEnable()
    {
        username = "NewUser";
        _inputField.text = username;
    }

    public void StoreUsername(string username)
    {
        this.username = username;
        GameController.i.playerController.Username = username;
    }

}
