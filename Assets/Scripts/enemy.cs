using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour, Health
{
    public float maxHealth = 100;
    public float health = 100;
    Rigidbody rigid;
    public void damage(float damageToTake, myEnums.damageType damageType,Transform damageSourcePosition)
    {
        //player - enemy
        Vector3 forceDirection = damageSourcePosition.position - this.transform.position;
        health -= damageToTake;
        rigid.AddRelativeForce(-forceDirection * 300);
        if (health <= 0)
        {
            onDeath();
        }
    }

    public float getHealth()
    {
        throw new System.NotImplementedException();
    }

    public float getMaxHealth()
    {
        throw new System.NotImplementedException();
    }

    public void onDeath()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
