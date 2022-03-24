using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _usernameText;

    public string username;

    //our base scriptable object reference
    public Profile _npcProfile;

    //profile body part image references
    public Image _pfpHead;
    public Image _pfpBody;
    public Image _pfpEyes;
    public Image _pfpMouth;
    public Image _pfpBackground;

    //random numbeer variables
    private int randHead;
    private int randBody;
    private int randEyes;
    private int randMouth;
    private int randBackground;

    // Start is called before the first frame update
    void Start()
    {
       //AssignNewProfile();
    }

    public void AssignNewProfile()
    {
        username = UsernameGenerator.GetUsername();
        _usernameText.text = "@" + username;

        randHead = Random.Range(0, _npcProfile._head.Length);
        _pfpHead.sprite = _npcProfile._head[randHead];

        randBody = Random.Range(0, _npcProfile._body.Length);
        _pfpBody.sprite = _npcProfile._body[randBody];

        randEyes = Random.Range(0, _npcProfile._eyes.Length);
        _pfpEyes.sprite = _npcProfile._eyes[randEyes];

        randMouth = Random.Range(0, _npcProfile._mouth.Length);
        _pfpMouth.sprite = _npcProfile._mouth[randMouth];

        randBackground = Random.Range(0, _npcProfile._background.Length);
        _pfpBackground.sprite = _npcProfile._background[randBackground];

    }

}
