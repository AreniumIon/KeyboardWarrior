using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // This could be display on the user's troll twitter account or something.
    string username = "DefaultUsername";
    public string Username { get => username; set => username = value; }

    public PlayerResources playerResources;

    public PlayerUpgrades playerUpgrades;

    // TODO: PlayerAchievements
}
