using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public void takeDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}