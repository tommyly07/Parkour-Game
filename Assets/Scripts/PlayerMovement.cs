using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator animation;
    private BoxCollider2D boxcollider;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask walllayer;
    private float WallJumpCooldown;
    private float move;




    private void Awake()
    {
        //Nimm die Referenzen für Rigidbody2D und Animator von Objekten
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }



    private void Update()
    {

        move = 0;

        //Bewegung mit Keyboard
        if (Keyboard.current.aKey.isPressed)
            move -= 1;
        if (Keyboard.current.dKey.isPressed)
            move += 1;

        //Spieler umdrehen, wenn er nach links oder rechts dreht
        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Animator paramater Boolean
        bool isRunning = move != 0;
        animation.SetBool("Run", isRunning);

        animation.SetBool("grounded", isGrounded());

        //wall jump logik
        if (WallJumpCooldown > 0.2f)
        {

            body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }
        }
        else
        {
            WallJumpCooldown += Time.deltaTime;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }



    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            animation.SetTrigger("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            WallJumpCooldown = 0;

            if (move == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                //1 schaut nacht rechts, -1 schaut nach links
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            }
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxcollider.bounds.center,
            boxcollider.bounds.size,
            0,
            Vector2.down, 0.3f,
            groundlayer);

        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxcollider.bounds.center,
            boxcollider.bounds.size,
             0,
             new Vector2(transform.localScale.x, 0),
             0.3f,
             walllayer);

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return true;
    }

    public bool canBlock()
    {
        return isGrounded() && !onWall();
    }

    public bool canShoot()
    {
        return isGrounded() && !onWall();
    }

}