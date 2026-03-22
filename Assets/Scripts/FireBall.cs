using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]private float speed;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator animation;


    private void Awake()
    {
        animation = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void update()
    {
        if(hit) return;

        float movementSpeed = speed * Time.deltaTime;
        
    }
}
