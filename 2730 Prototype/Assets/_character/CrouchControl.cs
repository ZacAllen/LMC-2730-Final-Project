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

    private bool ready;

    public void Init()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!ready)
            return;

        // user input to control crouching
        bool crouching = Input.GetKey(KeyCode.LeftShift);

        // raycast override
        RaycastHit hit;
        if (!crouching && Physics.Raycast(rayOrigin.position, Vector3.up, out hit, rayLength * transform.lossyScale.magnitude))
        {
            crouching = true;
        }
        Debug.DrawLine(rayOrigin.position, rayOrigin.position + Vector3.up * rayLength * transform.lossyScale.magnitude);


        anim.SetBool("crouching", crouching);

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
