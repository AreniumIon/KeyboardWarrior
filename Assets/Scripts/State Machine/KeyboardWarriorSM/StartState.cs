using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : KeyboardWarriorState
{
    bool loadFinished = false;

    public override void Enter()
    {
        CreatePlayer();
        StartCoroutine(EnterGameScene());
    }

    public override void Tick()
    {
        if (loadFinished)
        {
            stateMachine.ChangeState<SetupGameState>();
        }
    }

    public override void Exit()
    {
        loadFinished = false;
    }

    private void CreatePlayer()
    {
        SaveController.Load();

        GameController.i.playerController.SetParams();
    }

    IEnumerator EnterGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");

        // Dont change states until GameScene finishes loading
        while (!asyncLoad.isDone)
            yield return null;

        loadFinished = true;
    }
}
