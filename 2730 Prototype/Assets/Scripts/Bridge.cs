using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject trigger;

    public GameObject[] fallingBlocks;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fallingBlocks.Length; i++)
        {
            createTrigger(fallingBlocks[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createTrigger(GameObject block)
    {
        GameObject newTrigger = (GameObject) Instantiate(trigger);
        newTrigger.transform.SetParent(block.transform);
        newTrigger.transform.localPosition = new Vector3(0, 1.5f, 0);
    }
}
