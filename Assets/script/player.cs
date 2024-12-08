using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 6f;
    public float distante = 10f;

    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        hit = Physics2D.Raycast(transform.position, transform.right, distante);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, hit.point, Color.white);
            Debug.Log("попал");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.position+ transform.right * distante, Color.black);
            Debug.Log("мимо");
        }


    }
}
