using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool playerShot;
    //public bool inInventory;
    public GameObject crosshairs;
    //public GameObject inventory;
    //public GameObject mainCamera;
    public Animator cameraAnim;
    
    private void Start() {
    }

    private void Update() {       

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            cameraAnim.SetBool("Moving", true);
        }
        else {
            cameraAnim.SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.Space)) {
            cameraAnim.SetBool("Moving", false);
        }
        /*
        if (Input.GetKeyDown(KeyCode.E) && inInventory == false) {
            inInventory = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && inInventory == true) {
            inInventory = false;
        }
        if (inInventory == true) {
            inventory.SetActive(true);
            mainCamera.GetComponent<PlayerLook>().cursorLocked = false;
            mainCamera.GetComponent<PlayerLook>().mouseSensitivity = 0;
        }
        else {
            inventory.SetActive(false);
            mainCamera.GetComponent<PlayerLook>().cursorLocked = true;
            mainCamera.GetComponent<PlayerLook>().mouseSensitivity = 3.5f;
        }*/
    }


    void OnGUI() {
    }
}
