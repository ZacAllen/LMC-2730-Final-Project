using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    public bool shouldRotate = true;
    public float rotationSpeed = 5.0f;
    public float SmoothFactor = 0.5f;

    public float height = 5.0f;
    private float heightDamping;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var wantedHeight = PlayerTransform.position.y + height;
        var currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);


        if (shouldRotate)
        {
            Quaternion canTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime,
                   Vector3.up);
            _cameraOffset = canTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor * Time.deltaTime);

        if (shouldRotate && Time.timeScale > 0f)
        {
            //update height
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    

            //look at player
            transform.LookAt(PlayerTransform);
        }
    }
}
