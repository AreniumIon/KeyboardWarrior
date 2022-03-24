using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationGenerator
{
    static System.Random rnd = new System.Random();


    public static string CreateNormalComment()
    {
        return "Normal Comment";
    }

    public static string CreateSarcasticComment()
    {
        return "Sarcastic Comment";
    }

    public static string CreateTrollComment()
    {
        return "Troll Comment";
    }

    // Message sent by NPC
    static List<string> SUCCESS_CHARS = new List<string>()
    {
        "!",
        "@",
        "#",
        "$",
        "%",
        "^",
        "&",
        "*",
    };
    static int MIN_SUCCESS_CHARS = 8;
    static int MAX_SUCCESS_CHARS = 20;

    public static string CreateSuccessReply()
    {
        int chars = Random.Range(MIN_SUCCESS_CHARS, MAX_SUCCESS_CHARS);
        string str = "";

        for (int i = 0; i < chars; i++)
            str += SUCCESS_CHARS[rnd.Next(SUCCESS_CHARS.Count)];

        return str;
    }

    static List<string> STRIKE_REPLIES = new List<string>()
    {
        "Blocked!",
        "Get blocked!",
        "Reported!",
        "I'm reporting you!",
        "That's against TOS!",
        "You should be banned!",
    };

    public static string CreateStrikeReply()
    {
        return STRIKE_REPLIES[rnd.Next(STRIKE_REPLIES.Count)];
    }
}
