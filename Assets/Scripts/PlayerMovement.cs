using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    public float jumpForce = 5f;
    private Animator animation;
    private bool grounded;

    private void Awake()
    {
        //Nimm die Referenzen für Rigidbody2D und Animator von Objekten
        body = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
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
         if (Keyboard.current.spaceKey.wasPressedThisFrame && grounded){
         body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
         animation.SetTrigger("Jump");
         grounded = false;
         }


        //Animator paramater Boolean
        bool isRunning = move != 0;
        animation.SetBool("Run", isRunning);

        animation.SetBool("grounded", grounded);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        grounded = true;
    }
}

