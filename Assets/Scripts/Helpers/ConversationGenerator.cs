using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationGenerator
{
    // Message sent by player
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
    public static string CreateSuccessReply()
    {
        return "!@$@#^!";
    }
    
    public static string CreateStrikeReply()
    {
        return "I'm reporting you";
    }
}
