using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    static float AUTO_SAVE_SECONDS = 60f;

    // Have to store in separate script, because SaveController isn't a MonoBehavior, so it doesn't have access to OnApplicationQuit.
    private void OnApplicationQuit()
    {
        SaveController.Save();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoSave());
    }

    private IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(AUTO_SAVE_SECONDS);
        SaveController.Save();
        StartCoroutine(AutoSave());
    }
}
