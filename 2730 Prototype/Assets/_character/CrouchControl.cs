using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float rayLength;

    [SerializeField] private Collider standingCollider;
    [SerializeField] private Collider crouchingCollider;

    // Update is called once per frame
    void Update()
    {

        // user input to control crouching
        bool crouching = Input.GetKey(KeyCode.LeftShift);

        // raycast override
        RaycastHit hit;
        if (!crouching && Physics.Raycast(rayOrigin.position, Vector3.up, out hit, rayLength))
        {
            crouching = true;
        }

        anim.SetBool("crouching", Input.GetKey(KeyCode.LeftShift));

        if (crouching)
        {
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else
        {
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }

    }
}
