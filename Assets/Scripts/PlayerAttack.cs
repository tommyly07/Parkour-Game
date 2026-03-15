using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
   private Animator animation;
   private PlayerMovement playermovement;
   [SerializeField] private float AttackCooldown;
   private float cooldowntimer = Mathf.Infinity;


    private void Awake()
    {
        animation = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && cooldowntimer > AttackCooldown && playermovement.canAttack())
            Attack();

            cooldowntimer += Time.deltaTime;
    }

    private void Attack()
    {
        animation.SetTrigger("attack");
        cooldowntimer = 0;
    }
}
