using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.CompareTag("Player"))
        {
            Teleport();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.CompareTag("Player"))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        FindObjectOfType<GameController>().Win();
    }
}
