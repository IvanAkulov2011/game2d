using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour

{
    private Animator anim;
    private bool dead;
    public float startingHealth;
    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(float _damage) 
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if (currentHealth>0)
        {
            anim.SetTrigger("Flickering");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<Playermovment>().enabled= false;
                GetComponent<Playerattack>().enabled= true;
                dead = true;
               
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth +_value, 0, startingHealth);


    }
}
