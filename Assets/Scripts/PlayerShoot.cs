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

        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            return i;
        }
        
        
        return 0;
    }

}
