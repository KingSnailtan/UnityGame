using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    bool inradius = false;
    public GameObject player;
    public AnimationCurve myCurve;
    public GameObject bullet;
    public float bulletInterval = 2;
    // Start is called before the first frame update
   IEnumerator shootCoroutine()
    {
        while (true)
        {

            if (inradius)
            {
                shoot();
            }
            yield return new WaitForSecondsRealtime(bulletInterval);
        }
    }
    void shoot()
    {
        Instantiate(bullet, transform.position - new Vector3(0,1,0), transform.rotation);
    }
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
        else
        {
           
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
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("shootCoroutine");
    }
    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        inradius = false;
    }
}
