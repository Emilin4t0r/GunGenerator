using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {

	public float rotationSpeed;
	public float counter;
	public float maxCounter = 3f;
	public bool startSpinning;

	void Start() {

	}

	void Update() {

		if (counter > maxCounter) {
			startSpinning = true;
		} else {
			counter += Time.deltaTime;
		}

		if (startSpinning) {
			transform.Rotate(-Vector3.up * (rotationSpeed * Time.deltaTime));
		}
	}
}
