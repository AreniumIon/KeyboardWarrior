using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    // Have to store in separate script, because SaveController isn't a MonoBehavior, so it doesn't have access to OnApplicationQuit.
    private void OnApplicationQuit()
    {
        SaveController.Save();
    }
}
