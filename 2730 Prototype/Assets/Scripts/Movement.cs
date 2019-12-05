﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private Transform camera;

    [SerializeField] private Animator anim;

    [SerializeField] private float acceleration;
    [SerializeField] private float rotation;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float velocitySmoothing;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRayLength;
    [SerializeField] private float dontFallThroughFloorForce;

    private bool jumping;
    private Vector3 refVel;

    private bool ready;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        ready = true;
    }

    void Update()
    {
        if (!ready)
            return;
        // grab inputs
        Vector2 velIns = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool moving = velIns.magnitude > 0.05f;
        //float rotation = Vector2.Angle(Vector2.up, velIns);

        bool jumpCtrl = Input.GetButtonDown("Jump");


        // determine if we're jumping
        RaycastHit hit;
        Debug.DrawLine(transform.position + Vector3.up * jumpRayLength * transform.localScale.y, transform.position - Vector3.up * jumpRayLength * transform.localScale.y);
        if (Physics.Raycast(transform.position + Vector3.up * jumpRayLength * transform.localScale.y, -Vector3.up, out hit, 2 * jumpRayLength * transform.localScale.y))
        {
            // did we hit the ground
            if (rb.velocity.y <= 0 && rb.velocity.y > -0.05f)
            {
                jumping = false;
            }

        }
        else
        {
            // there's nothing under our feets
            jumping = true;
        }

        // manually reposition ourself based on bounding box
        if (!jumping)
        {
            if (Physics.Raycast(transform.position + Vector3.up * jumpRayLength * transform.localScale.y, -Vector3.up, out hit, 2 * jumpRayLength * transform.localScale.y))
            {

                Collider c = null;

                foreach (Collider cPot in GetComponentsInChildren<Collider>()) // this is extremely hardcoded and bad
                {
                    if (cPot.enabled)
                        c = cPot;
                }

                //rb.velocity = new Vector3(rb.velocity.x, 0.1f, rb.velocity.z);
                //rb.MovePosition(new Vector3(transform.position.x, transform.position.y + (hit.point.y - c.bounds.min.y) + 0.01f, transform.position.z));

                rb.AddForce(Vector3.up * dontFallThroughFloorForce * Time.deltaTime);

                
            }
        }

        // apply forces to rigidbody
        if (moving)
        {
            Vector3 direction = camera.TransformDirection(new Vector3(velIns.x, 0, velIns.y));

            Vector3 movement = Vector3.Scale(direction, new Vector3(1, 0, 1));

            rb.AddForce(movement * acceleration * Mathf.Sqrt(transform.localScale.x) * Time.deltaTime);
            rb.MoveRotation(Quaternion.LookRotation(movement.normalized, Vector3.up));   

        }


        if (jumpCtrl && !jumping)
        {
            rb.AddForce(Vector3.up * jumpForce * Mathf.Sqrt(transform.localScale.x), ForceMode.Impulse);
            jumping = true;
        }

        //transform.Rotate(Vector3.up, rotIn * rotation * Time.deltaTime);

        // cap xz velocity

        Vector3 xzVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (xzVel.magnitude > maxSpeed)
        {
            xzVel = xzVel.normalized * maxSpeed;
            rb.velocity = new Vector3(xzVel.x, rb.velocity.y, xzVel.z);
        }

        // then smooth xz velocity back to zero
        rb.velocity = Vector3.SmoothDamp(
            rb.velocity,
            new Vector3(0, rb.velocity.y, 0),
            ref refVel,
            velocitySmoothing);


        // animations

        if (anim)
        {
            anim.SetBool("jumping", jumping);
            anim.SetFloat("forward", velIns.magnitude);
        }



    }
}