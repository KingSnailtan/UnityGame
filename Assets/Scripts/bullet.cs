using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public  int lifetime = 1;
    public float speed;
    public myEnums.damageType damageType;
    public float damageAmount;
    // Start is called before the first frame update
    IEnumerator counter()
    {
        yield return new WaitForSeconds(lifetime);
        Debug.Log("Time death");
        Destroy(this.gameObject);
    }
    void Start()
    {
        StartCoroutine(counter());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().damage(damageAmount, damageType,this.transform);
        }
        Debug.Log("Hit death");
        Destroy(this.gameObject);
    }
   

}
