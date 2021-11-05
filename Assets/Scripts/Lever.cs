using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lever : MonoBehaviour
{
    protected BoxCollider2D boxCollider;

    protected void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            affectScene();
        }
    }

    //do whatever the specific lever does 
    protected abstract void affectScene();
}
