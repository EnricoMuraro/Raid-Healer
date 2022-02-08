using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 100;
        healthBar.value = 0;
    }

    public void SetMaxHealth(int maxHp) 
    {
        healthBar.maxValue = maxHp;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
