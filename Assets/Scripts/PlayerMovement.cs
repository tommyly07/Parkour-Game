using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;
    private Animator animation;
    private BoxCollider2D boxcollider;
    [SerializeField]private LayerMask groundlayer;




    private void Awake()
    {
        //Nimm die Referenzen für Rigidbody2D und Animator von Objekten
        body = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }



    private void Update()
    {
       float move = 0;

        //Bewegung mit Keyboard
        if(Keyboard.current.aKey.isPressed)
        move -= 1;
        if(Keyboard.current.dKey.isPressed)
        move += 1;

        //Bewegung
        body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

        //Spieler umdrehen, wenn er nach links oder rechts dreht
        if(move > 0)
        transform.localScale = new Vector3(1,1,1);
        else if(move < 0)
        transform.localScale = new Vector3(-1,1,1);

        //Springen
         if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded()){
         body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
         animation.SetTrigger("Jump");
         }

        //Animator paramater Boolean
        bool isRunning = move != 0;
        animation.SetBool("Run", isRunning);

        animation.SetBool("grounded", isGrounded());
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }



    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.3f, groundlayer);
        return raycastHit.collider != null;
    }
}

