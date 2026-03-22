using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed; // Geschwindigkeit des Projektils

    private bool hit; // merkt sich ob die Fireball schon etwas getroffen hat
    private BoxCollider2D boxCollider;
    private Animator animation;
    private float direction; // Flugrichtung (links oder rechts)
    private float lifetime; // wie lange die Fireball existiert


    private void Awake()
    {
        animation = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // wenn die Fireball bereits etwas getroffen hat -> nichts mehr bewegen
        if (hit) return;

        // Bewegung der Fireball
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;

        if (lifetime > 5)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // wenn die Fireball etwas trifft
        hit = true;

        // Collider deaktivieren damit keine weiteren Treffer passieren
        boxCollider.enabled = false;
        animation.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;

        // Flugrichtung setzen
        direction = _direction;

        // Fireball aktivieren
        gameObject.SetActive(true);
        hit = false;

        // Collider wieder aktivieren
        boxCollider.enabled = true;

        // Sprite drehen je nach Richtung
        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}