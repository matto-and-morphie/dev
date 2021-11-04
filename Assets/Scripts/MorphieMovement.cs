using UnityEngine;

public class MorphieMovement : PlayerMovement
{
    new public void Awake() {
        base.Awake();
        jumpPower *= -1;
        groundDirection = Vector2.up;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
        jumpKey = KeyCode.W;
    }
}
