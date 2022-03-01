using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FollowerPointGain : MonoBehaviour
{
    bool inRoutine = false;
    int gainThisTurn = 0;
    float waitTime = 100f;

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

        try
        {
            waitTime = playerResources.FollowerCPTime;            //this causes an error because of a race condition with player resources!
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Null reference Exeption in Follower Count Gain Time! :: " + e);
        }

        yield return new WaitForSecondsRealtime(waitTime);

        //add followers X FollowerCPGain CP to total
        /*
        gainThisTurn = (int)Mathf.Round(
                playerResources.Followers * playerResources.FollowerCPGain 
            );
        */
        gainThisTurn = (int)Mathf.Round(
                playerResources.Followers * playerResources.FollowerCPGain
            );

        //Debug.Log("Followers gained " + gainThisTurn + " CP!");
        playerResources.CP += gainThisTurn;

        inRoutine = false;
    }
}
