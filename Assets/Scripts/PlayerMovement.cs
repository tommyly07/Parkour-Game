using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    public float jumpForce = 5f;

    private void Awake()
    {
        //Rigidbody2D wird in body gespeichert
        body = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
       float move = 0;

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

        //Wenn wir SpaceTaste gedrückt halten, erhöhen wir die Geschwindigkeit nach oben
         if (Keyboard.current.spaceKey.wasPressedThisFrame)
         body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }


}

