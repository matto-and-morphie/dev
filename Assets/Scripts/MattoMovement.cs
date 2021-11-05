using UnityEngine;

public class MattoMovement : PlayerMovement
{
    [SerializeField] private GameObject morphie;
    private Rigidbody2D morphieBody;

    new public void Awake() {
        base.Awake();
        groundDirection = Vector2.down;
        leftKey = KeyCode.LeftArrow;
        rightKey = KeyCode.RightArrow;
        jumpKey = KeyCode.UpArrow;

        //ignore collisions with morphie
        morphieBody = morphie.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(morphieBody.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
    }
}
