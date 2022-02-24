using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputUsernameController : MonoBehaviour
{
    //string _userName = "";
    //string UserName => _userName;

    public void StoreUsername(string username)
    {
        Debug.Log("Edited: " + username);
        GameController.i.playerController.Username = username;
        //_userName = username;
        //_textDisplay.GetComponent<TextMeshProUGUI>().text = "@" + _userName;
    }

}
