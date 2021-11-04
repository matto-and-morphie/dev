using UnityEngine;

public class MattoMovement : PlayerMovement
{
    new public void Awake() {
        base.Awake();
        groundDirection = Vector2.down;
        leftKey = KeyCode.LeftArrow;
        rightKey = KeyCode.RightArrow;
        jumpKey = KeyCode.UpArrow;
    }
}
