using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommentOutcomeCalc;

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
        " ",
        "!",
        "@",
        "#",
        "$",
        "%",
        "^",
        "&",
        "*",
    };
    static Dictionary<ButtonType, int> CHARS_BY_RISK = new Dictionary<ButtonType, int>()
    {
        {ButtonType.Safe, 7 },
        {ButtonType.Sarcastic, 15 },
        {ButtonType.Troll, 25 },
    };

    public static string CreateSuccessReply(ButtonType buttonType)
    {
        int chars = CHARS_BY_RISK[buttonType];
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
