using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackCooldown;
    public Transform firePoint;
    public GameObject[] fireBalls;
    private Animator anim;
    private PlayerMovement playermov;
    private float cooldownTimer = Mathf.Infinity;
    void Start()
    {
        anim = GetComponent<Animator>();
        playermov = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playermov.CanAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireBalls[FindFireBall()].transform.position = firePoint.position;
        fireBalls[FindFireBall()].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
