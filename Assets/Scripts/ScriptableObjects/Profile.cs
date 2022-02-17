using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Profile", menuName = "Profile")]
public class Profile : ScriptableObject
{
    public Sprite[] _head;
    public Sprite[] _body;
    public Sprite[] _eyes;
    public Sprite[] _mouth;
    public Sprite[] _background;

}
