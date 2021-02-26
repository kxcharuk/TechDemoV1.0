using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get => health;
    }
    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get => maxHealth;
    }
    private bool isAlive;
    public bool IsAlive
    {
        get => isAlive;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
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
            isAlive = false;
        }
    }

}
