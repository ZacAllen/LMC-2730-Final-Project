using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private Transform tracker;
    [SerializeField] private Transform lookAt;
    [SerializeField] private Transform scale;

    private float distance;

    private float vertical;
    private float horizontal;
    [SerializeField] private float vScale;
    [SerializeField] private Vector2 vClamp;
    [SerializeField] private float hScale;

    private Vector3 velRef;
    [SerializeField] private float smoothing;


    private void Awake()
    {
        distance = (transform.position - lookAt.position).magnitude;

        vertical = vClamp.x + vClamp.y / 2f;
    }

    private void Start()
    {
        tracker = new GameObject("camera tracker").transform;
        Application.targetFrameRate = 30;

    }

    private void Update()
    {
        Debug.Log(Application.targetFrameRate);
        Application.targetFrameRate += Input.GetKeyDown(KeyCode.X) ? 1 : 0;
        Application.targetFrameRate -= Input.GetKeyDown(KeyCode.Z) ? 1 : 0;


        tracker.position = lookAt.position - Vector3.forward * distance * scale.localScale.x;
        tracker.RotateAround(lookAt.position, Vector3.right, vertical);

        tracker.RotateAround(lookAt.position, Vector3.up, horizontal);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            tracker.position,
            ref velRef,
            smoothing);
        transform.LookAt(lookAt);

        vertical += Input.GetAxis("Mouse Y") * vScale * Time.deltaTime;
        vertical = Mathf.Clamp(vertical, vClamp.x, vClamp.y);

        horizontal += Input.GetAxis("Mouse X") * hScale * Time.deltaTime;
    }
}
