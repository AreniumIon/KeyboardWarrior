using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputUsernameController : MonoBehaviour
{
    [SerializeField] public string _userName = "";
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] GameObject _textDisplay = null;

    public void StoreUsername()
    {
        if(string.IsNullOrEmpty(_inputField.text))
        {
            _userName = "User";
            _textDisplay.GetComponent<TextMeshProUGUI>().text = "@" + _userName;
        }
        else
        {
            _userName = _inputField.text;
            _textDisplay.GetComponent<TextMeshProUGUI>().text = "@" + _userName;
        }
    }

}
