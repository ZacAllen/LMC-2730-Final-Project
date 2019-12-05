﻿using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
        private float distance = 10f;
        [SerializeField] private float yScale;
		// the height we want the camera to be above the target
		[SerializeField]
		private Vector2 heights = new Vector2(0.1f, 1);
        private float height;
		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

		// Use this for initialization
		void Start()
        {
            height = heights.x;
        }

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

            // vertical scrolling
            height += Input.GetAxis("Mouse Y") * yScale * Time.deltaTime;
            height = Mathf.Clamp(height, heights.x, heights.y);


			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height * Mathf.Sqrt(target.localScale.magnitude);

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance * Mathf.Sqrt(target.localScale.magnitude);

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,wantedHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);

            // raytrace to make sure there's no geometry between camera and follow transform

            RaycastHit hit;

            if (Physics.Raycast(target.transform.position, (transform.position - target.transform.position), out hit, (transform.position - target.transform.position).magnitude))
            {
                transform.position = hit.point;
            }
		}
	}
}