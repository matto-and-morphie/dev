using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : Lever
{
    [SerializeField] private GameObject groundToMove;
    [SerializeField] private GameObject groundTarget;
    [SerializeField] private float moveSpeed;
    private float distanceToMove = 0;
    
    protected override void affectScene() {
        distanceToMove = Time.deltaTime;
    }

    private void Update() {
        groundToMove.transform.position = groundToMove.transform.position + new Vector3(0, distanceToMove, 0);
        if (groundToMove.transform.position.y > groundTarget.transform.position.y)
        {
            distanceToMove = 0;
        }
    }
}
