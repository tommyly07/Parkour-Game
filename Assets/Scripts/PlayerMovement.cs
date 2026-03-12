using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;

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

       body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

    }
}

