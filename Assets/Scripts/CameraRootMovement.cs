using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRootMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject p1;
    [SerializeField]
    public GameObject p2;
    [SerializeField]
    public GameObject bottomLeft;
    [SerializeField]
    public GameObject topRight;
    
    float camHeight;
    float camWidth;
    float leftBound;
    float rightBound;
    float upperBound;
    float lowerBound;

    void Start()
    {
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        leftBound = bottomLeft.transform.position.x;
        rightBound = topRight.transform.position.x;
        upperBound = topRight.transform.position.y;
        lowerBound = bottomLeft.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rootPosition = (p1.transform.position + p2.transform.position) / 2;

        //modify x position
        if ((rootPosition.x - camWidth / 2) < leftBound){
            rootPosition.x = leftBound + camWidth / 2;
        } else if ((rootPosition.x + camWidth / 2) > rightBound){
            rootPosition.x = rightBound - camWidth / 2;
        }

        //modify y position
        if ((rootPosition.y - camHeight / 2) < lowerBound){
            rootPosition.y = lowerBound + camHeight / 2;
        } else if ((rootPosition.y + camHeight / 2) > upperBound){
            rootPosition.y = upperBound - camHeight / 2;
        }

        gameObject.transform.position = rootPosition;
    }
}
