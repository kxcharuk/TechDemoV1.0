using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int health;
    private int maxHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if(amount < 0)
        {
            Debug.Log("Negative value passed into TakeDamage() amount = " + amount);
        }
        health -= amount;
        RangeCheck();
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            Debug.Log("Negative value passed into Heal() amount = " + amount);
        }
        health += amount;
        RangeCheck();
    }


    private void RangeCheck()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        else if(health < 0)
        {
            health = 0;
            // die functionality in here
        }
    }

}
