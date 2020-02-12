using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour
{
    bool canDamage = true;
    float attackDelay = 1;
    // Start is called before the first frame update
    IEnumerator damageTimer()
    {
        yield return new WaitForSeconds(attackDelay);
        canDamage = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(0))
        {
            if (other.gameObject.GetComponent<Health>() != null && canDamage)
            {

                Debug.Log("Help");
                other.gameObject.GetComponent<Health>().damage(15, myEnums.damageType.player,this.transform);
                canDamage = false;
                StartCoroutine(damageTimer());
            }
        }
    }
}
