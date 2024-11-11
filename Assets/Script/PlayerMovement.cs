using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment: MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D body;
    private Animator anim;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            Jump();
        }
        //flip
        if (horizontal > -0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }




        //anim
        anim.SetBool("move", horizontal != 0);
        anim.SetBool("ground", grounded);

    }

        private void OnCollisionEnter2D(Collision2D collision)

        {
            if (collision.gameObject.tag == "ground")
            {
                grounded = true;
            }
        }




        private void Jump()
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            grounded = false;
        }



    }