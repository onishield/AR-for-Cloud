﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePreview : MonoBehaviour {

	float rotateSpeed = 100;

	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

		transform.Rotate (Vector3.up, -rotX);
		transform.Rotate (Vector3.right, rotY);
	}
}
