using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject dragon;
    public GameObject pig;
    public float speed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player1 = dragon.transform.position;
        Vector2 vrag1 = pig.transform.position;

        if (Vector2.Distance(player1, vrag1) < 16)
        {
            pig.transform.position = Vector2.MoveTowards(vrag1, player1, speed * Time.deltaTime);
        }
    }

}
