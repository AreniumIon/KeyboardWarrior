using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
public class ButtonHover : MonoBehaviour
{
    public float heightGain = 10f;
    //public float speed = .1f;

    Vector3 lowPosition;
    Vector3 highPosition;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        lowPosition = transform.position;
        highPosition = lowPosition + new Vector3(0, heightGain, 0);

        targetPosition = lowPosition;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    /*
    void OnMouseOver()
    {
        Debug.Log("Mouse hover over!");
        targetPosition = highPosition;
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse hover exit!");
        targetPosition = lowPosition;
    }*/

    public void MouseOver()
    {
        //Debug.Log("Mouse hover over!");
        targetPosition = highPosition;
    }

    public void MouseExit()
    {
        //Debug.Log("Mouse hover exit!");
        targetPosition = lowPosition;
    }
}
