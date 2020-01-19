using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int woodAmt;
    public bool treeTargeted;
    public bool treeWasHit;
    public bool inInventory;
    public GameObject crosshairs;
    public GameObject inventory;
    public GameObject mainCamera;

    private void Start() {
    }

    private void Update() {

       /* //Tree detecting and hitting
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 2) && hit.transform.tag == "Tree" && axe.activeSelf == true) {
            Debug.DrawRay(transform.position, fwd, Color.red, 10);
            treeTargeted = true;
        }
        else {
            treeTargeted = false;

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
