using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    private float direction;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private bool hit;
    private float lifeTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit)
        {
            return;
        }    
        float movementspeed = speed * Time.deltaTime *direction;
        transform.Translate(movementspeed, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > 5)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        if (collision.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        float localscaleX = transform.localScale.x;
        if (Mathf.Sign(localscaleX) != _direction)
        {
            localscaleX = -localscaleX;
        }
        transform.localScale = new Vector3(localscaleX, transform.localScale.y, transform.localScale.z);
    }    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Deactivate();
        }
    }
}
