using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private Animator animation;
    private PlayerMovement playermovement;
    [SerializeField] private float ShootCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldowntimer = Mathf.Infinity;


    private void Awake()
    {
        animation = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame && cooldowntimer > ShootCooldown && playermovement.canShoot())
            Shoot();

            cooldowntimer += Time.deltaTime;
        
    }

    private void Shoot()
    {
        animation.SetTrigger("shoot");
        cooldowntimer = 0;

        fireballs[0].transform.position = firepoint.position;
        fireballs[0].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
