using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController i;

    public KeyboardWarriorSM keyboardWarriorSM;

    public PlayerController playerController;

    public UIController uiController;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
