using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    public Transform firepoint;
    public GameObject[] fireBalls;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = Getcomponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
