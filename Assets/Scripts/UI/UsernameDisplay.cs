using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _usernameText;

    private void OnEnable()
    {
        _usernameText.text = "@" + GameController.i.playerController.Username;
    }
}
