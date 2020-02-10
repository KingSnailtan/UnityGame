using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    bool inradius = false;
    public GameObject player;
    public AnimationCurve myCurve;
    
    // Start is called before the first frame update
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!inradius)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90, 0, 0), 3f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inradius = true;
            if (transform.rotation != Quaternion.LookRotation(other.transform.position - transform.position))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(other.transform.position - transform.position), 3f);

            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inradius = false;
    }
}
