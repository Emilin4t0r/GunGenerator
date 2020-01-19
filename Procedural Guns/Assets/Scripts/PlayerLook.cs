using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivity;
    public Transform PlayerBody;
    public bool cursorLocked;

    private float xAxisClamp;

    private void Awake() {
        xAxisClamp = 0.0f;
    }


    private void LockCursor() { //when want to lock cursor to screen
        if (cursorLocked == true) {
            Cursor.lockState = CursorLockMode.Locked;
        } else if (cursorLocked == false) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update() {
        CameraRotation();
        LockCursor();
    }

    private void CameraRotation() {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity;

        xAxisClamp += mouseY;
        if (xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
