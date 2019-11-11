using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeFall : MonoBehaviour
{
    bool falling = false;
    Transform parent;

    private void Start()
    {
        parent = transform.parent;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            falling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            if (parent.position.y < -12f)
            {
                Destroy(gameObject);
            }
            parent.position = new Vector3(parent.position.x, parent.position.y - 0.05f, parent.position.z);
        }
    }
}
