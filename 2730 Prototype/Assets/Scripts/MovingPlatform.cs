using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // parent player when he collides with this

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision Enter");
            // this is kinda hardcoded since I know the rigidbody is one child down
            Transform player = c.rigidbody.transform.parent;
            player.parent = transform;
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            // this is kinda hardcoded since I know the rigidbody is one child down
            Transform player = c.rigidbody.transform.parent;
            player.parent = null;
        }
    }
}
