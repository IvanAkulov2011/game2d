using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Heart playerHealth;
    public Image hp_total;
    public Image hp_current;
    // Start is called before the first frame update
    void Start()
    {
        hp_total.fillAmount = playerHealth.startingHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        hp_current.fillAmount = playerHealth.currentHealth / 10;
    }
}
