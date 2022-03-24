using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommentOutcomeCalc;

public static class ConversationGenerator
{
    static System.Random rnd = new System.Random();

    static List<string> MESSAGE_CHARS = new List<string>()
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

    static Dictionary<ButtonType, int> PLAYER_CHARS_BY_RISK = new Dictionary<ButtonType, int>()
    {
        {ButtonType.Safe, 7 },
        {ButtonType.Sarcastic, 10 },
        {ButtonType.Troll, 15 },
    };

    public static string CreatePlayerComment(ButtonType buttonType)
    {
        int chars = PLAYER_CHARS_BY_RISK[buttonType];
        string str = "";

        for (int i = 0; i < chars; i++)
            str += MESSAGE_CHARS[rnd.Next(MESSAGE_CHARS.Count)];

        return str;
    }


    static Dictionary<ButtonType, int> REPLY_CHARS_BY_RISK = new Dictionary<ButtonType, int>()
    {
        {ButtonType.Safe, 7 },
        {ButtonType.Sarcastic, 15 },
        {ButtonType.Troll, 25 },
    };

    public static string CreateSuccessReply(ButtonType buttonType)
    {
        int chars = REPLY_CHARS_BY_RISK[buttonType];
        string str = "";

        for (int i = 0; i < chars; i++)
            str += MESSAGE_CHARS[rnd.Next(MESSAGE_CHARS.Count)];

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
