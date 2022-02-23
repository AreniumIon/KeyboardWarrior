using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPointGain : MonoBehaviour
{
    int gainThisTurn = 0;
    bool inRoutine = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Follower Point Gain Time!");
        //Time.timeScale = 1;
        
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
        //Debug.Log("Waiting...");
        yield return null;//new WaitForSecondsRealtime(1f);
        Debug.Log("Done Waiting");

        //add followers X FollowerCPGain CP to total
        gainThisTurn = (int)Mathf.Round(
                GameController.i.playerController.playerResources.Followers
                * GameController.i.playerController.playerResources.FollowerCPGain
            );

        Debug.Log("Followers gained " + gainThisTurn + " CP!");
        GameController.i.playerController.playerResources.CP += gainThisTurn;

        inRoutine = false;
    }
}
