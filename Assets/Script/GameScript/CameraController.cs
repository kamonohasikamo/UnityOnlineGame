﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
	private const float angleMin = -89.0f;
	private const float angleMax = 89.0f;

	public Transform target;
	public Vector3 offset;
	private Vector3 lookAt;

	private float distance = 10.0f;
	private float distance_min = 1.0f;
	private float distance_max = 20.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;

	private float moveX = 4.0f;
	private float moveY = 2.0f;
	private float moveX_QE = 2.0f;


	void Update() {
		if (Input.GetKey(KeyCode.Q)) {
			currentX += -moveX_QE;
		}
		if (Input.GetKey(KeyCode.E)) {
			currentX += moveX_QE;
		}

		if (Input.GetMouseButton(1)) {
			currentX += Input.GetAxis("Mouse X") * moveX;
			currentY += Input.GetAxis("Mouse Y") * moveY;
			currentY = Mathf.Clamp(currentY, angleMin, angleMax);
		}
		distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel"), distance_min, distance_max);
	}

	void LateUpdate() {
		if (target != null) {
			lookAt = target.position + offset;

			Vector3 dir = new Vector3(0, 0, -distance);
			Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);

			transform.position = lookAt + rotation * dir;
			transform.LookAt(lookAt);
		}
	}
}
