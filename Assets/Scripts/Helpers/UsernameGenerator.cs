using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class UsernameGenerator
{
    static System.Random rnd = new System.Random();

    public static string GetUsername()
    {
        string adj = userAdjectives[rnd.Next(userAdjectives.Count)];
        string noun = userNouns[rnd.Next(userNouns.Count)];
        string num = GetRandomNumber().ToString();

        return adj + noun + num;
    }

    static List<string> userAdjectives = new List<string>()
    {
        "Big",
        "Small",
        "Cool",
        "Awesome",
        "Online",
        "Epic",
    };

    static List<string> userNouns = new List<string>()
    {
        "Person",
        "Troll",
        "Monkey",
        "Elephant",
        "Dog",
        "Alien",
    };

    static int minNum = 0;
    static int maxNum = 999;

    static int GetRandomNumber()
    {
        return UnityEngine.Random.Range(minNum, maxNum);
    }
}
