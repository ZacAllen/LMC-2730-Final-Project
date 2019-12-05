using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.CompareTag("Player"))
        {
            Kill();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.CompareTag("Player"))
        {
            Kill();
        }
    }

    private void Kill()
    {
        FindObjectOfType<GameController>().Lose();
    }
}
