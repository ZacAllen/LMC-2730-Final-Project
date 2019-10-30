using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * 4);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 4);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * 4);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 4);
        }
    }
}
