using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, Health
{
    public float health = 100f, maxHealth = 100f;
    public void damage(float damageToTake, myEnums.damageType damageType)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            onDeath();
        }
    }

    public float getHealth()
    {
        return health;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void onDeath()
    {
        Debug.Log("I died");
        health = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
