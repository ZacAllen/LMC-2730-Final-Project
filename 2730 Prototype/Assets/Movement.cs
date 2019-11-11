using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private Animator anim;

    [SerializeField] private float acceleration;
    [SerializeField] private float rotation;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float velocitySmoothing;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRayLength;

    private bool jumping;
    private Vector3 refVel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // grab inputs
        Vector2 velIns = new Vector2(0, Input.GetAxis("Vertical"));
        bool jumpCtrl = Input.GetButtonDown("Jump");
        float rotIn = Input.GetAxis("Horizontal");

        // check to see if we're on the ground
        if (jumping && rb.velocity.y < 0)
        {
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position - Vector3.up * jumpRayLength * transform.localScale.y);
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, jumpRayLength * transform.localScale.y))
            {
                jumping = false;
            }
        }

        // apply forces to rigidbody

        rb.AddForce((transform.right * velIns.x + transform.forward * velIns.y) * acceleration * Time.deltaTime);
        if (jumpCtrl && !jumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }

        transform.Rotate(Vector3.up, rotIn * rotation * Time.deltaTime);

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
            anim.SetFloat("forward", velIns.y);
        }



    }
}
