using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    private Animator animation;
    private PlayerMovement playerMovement;
    [SerializeField] private float BlockCooldown;
    private float cooldowntimer = Mathf.Infinity;


    private void Awake()
    {
        animation = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Mouse.current.rightButton.isPressed && cooldowntimer > BlockCooldown && playerMovement.canBlock())
        Block();

        cooldowntimer += Time.deltaTime;
    }

    private void Block()
    {
        animation.SetTrigger("block");
        cooldowntimer = 0;
    }
}
