using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeTimer : MonoBehaviour
{
    float x = 0.5f;
    float y = 0.5f;
    float z = 0.5f;

    public float smoothTime = 0.3f;
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        player.transform.localScale = new Vector3(x, y, z);

        x += 0.001f;
        y += 0.001f;
        z += 0.001f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "shrinkPotion")
        {
            GameObject player = GameObject.Find("Player");
            x -= 0.7f;
            y -= 0.7f;
            z -= 0.7f;
            player.transform.localScale = new Vector3(x, y, z);
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "guard")
        {
            //will animate guard later
            GameObject player = GameObject.Find("Player");
            Destroy(player);
        }
    }
}
