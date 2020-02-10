using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rigid;
    public float speedMultiplier;
    GameObject mainCamFocus;
    public bool invertY = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCamFocus = GameObject.FindGameObjectWithTag("CameraFocus");
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement();
    }
    private void FixedUpdate()
    {
        walking();
    }
    public void cameraMovement()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X"), transform.rotation.eulerAngles.z);
        if (invertY)
        {
            mainCamFocus.transform.rotation = Quaternion.Euler(mainCamFocus.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y"), mainCamFocus.transform.rotation.eulerAngles.y, mainCamFocus.transform.rotation.eulerAngles.z);
        }
        else
        {
            mainCamFocus.transform.rotation = Quaternion.Euler(mainCamFocus.transform.rotation.eulerAngles.x + Input.GetAxis("Mouse Y") , mainCamFocus.transform.rotation.eulerAngles.y, mainCamFocus.transform.rotation.eulerAngles.z);
        }
    }
    private void walking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddRelativeForce(Vector3.forward * speedMultiplier);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddRelativeForce(Vector3.back * speedMultiplier);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddRelativeForce(Vector3.left * speedMultiplier);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddRelativeForce(Vector3.right * speedMultiplier);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
           
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                rigid.velocity = rigid.velocity / 3;
                Debug.Log("AH");
            }
        }
    }
}
