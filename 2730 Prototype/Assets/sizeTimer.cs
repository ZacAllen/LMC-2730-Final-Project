using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeTimer : MonoBehaviour
{
    float x = 0.5f;
    float y = 0.5f;
    float z = 0.5f;

    [SerializeField] private GameObject player;

    [SerializeField] private float rate;

    [SerializeField] private Animator anim;
    private float startSize;
    [SerializeField] private float maxSize;

    public float smoothTime = 0.3f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.localScale = new Vector3(x, y, z);

        startSize = player.transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.localScale = new Vector3(x, y, z);

        x += rate * Time.deltaTime;
        y += rate * Time.deltaTime;
        z += rate * Time.deltaTime;

        float range = maxSize - startSize;

        float percent = 1 - (maxSize - player.transform.localScale.magnitude) / range;

        if (anim)
            anim.SetFloat("size", percent);
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
