using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPointGain : MonoBehaviour
{
    bool inRoutine = false;
    int gainThisTurn = 0;
    float waitTime = 0f;

    PlayerResources playerResources;

    void Start()
    {
        playerResources = GameController.i.playerController.playerResources;
    }

    void OnEnable()
    {
        //Debug.Log("Follower Point Gain Time!");

        //start coroutine again if the canvas is reawakened
        inRoutine = false;
        StartCoroutine(FollowerCPCoroutine());
    }

    void FixedUpdate()
    {
        if (!inRoutine)
        {
            //Debug.Log("calling routine");
            StartCoroutine(FollowerCPCoroutine());
        }
    }

    IEnumerator FollowerCPCoroutine()
    {
        //Time.timeScale = 1;
        inRoutine = true;
        //wait followerCPTime seconds
        waitTime = 2; // playerResources.FollowerCPTime;            //this causes an error because of a race condition with player resources!
        yield return new WaitForSecondsRealtime(waitTime);

        //add followers X FollowerCPGain CP to total
        gainThisTurn = (int)Mathf.Round(
                playerResources.Followers * playerResources.FollowerCPGain 
            );

        //Debug.Log("Followers gained " + gainThisTurn + " CP!");
        playerResources.CP += gainThisTurn;

        inRoutine = false;
    }
}
