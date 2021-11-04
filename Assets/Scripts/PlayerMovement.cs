
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //set fields
    private Rigidbody2D body;
    //private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] protected LayerMask groundLayer;
    private float speed = 5;
    private float horizontalInput;
    private float scale;

    //modifiable fields
    protected float jumpPower = 8;
    protected Vector2 groundDirection;
    protected KeyCode leftKey;
    protected KeyCode rightKey;
    protected KeyCode jumpKey;
    
    protected void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        scale = transform.localScale.x;
    }

    private void Update()
    {
        SetHorizontalInput();

        if (onWall()){
            body.velocity = new Vector2(0, body.velocity.y);
        } else {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
        

        if (Input.GetKey(jumpKey))
            Jump();

        // flip player
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one * scale;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1) * scale;

        // anim.SetBool("run", horizontalInput != 0);
        // anim.SetBool("grounded", isGrounded());
    }

    //method to get horizontal input
    private void SetHorizontalInput() {
        if (Input.GetKey(leftKey) && !Input.GetKey(rightKey)) {
            horizontalInput = -1;
        }
        else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey)) {
            horizontalInput =  1;
        }
        else {
            horizontalInput = 0;
        }
    }

    //method for jumping
    private void Jump() {
        if (isGrounded()) {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            // anim.SetTrigger("Key");
        }
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
        boxCollider.bounds.size, 0, groundDirection, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
        boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    // public bool canAttack() {
    //     return horizontalInput == 0 && isGrounded() && !onWall();
    // }


}