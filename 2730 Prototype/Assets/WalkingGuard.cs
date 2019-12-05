using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingGuard : MonoBehaviour
{
    [SerializeField] private Transform t;
    private Vector3 lastPos;

    private void Update()
    {
        Vector3 direction = (t.position - lastPos).normalized;

        transform.eulerAngles = new Vector3(0, Vector3.SignedAngle(Vector3.forward, direction, Vector3.up), 0);

        lastPos = t.position;
    }
}
