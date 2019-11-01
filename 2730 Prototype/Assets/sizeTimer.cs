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
        //Vector3 targetSize = new Vector3(1, 1, 1);


        player.transform.localScale = new Vector3(x, y, z);

        x += 0.0005f;
        y += 0.0005f;
        z += 0.0005f;

        //doing this wrong
        //player.transform.localScale = Vector3.SmoothDamp(player.transform.localScale,
            //targetSize, ref velocity, smoothTime);

    }
}
