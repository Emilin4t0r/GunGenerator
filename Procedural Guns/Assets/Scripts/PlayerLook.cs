using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivity;
    public Transform PlayerBody;
    public bool cursorLocked;
    public GameObject gunHolder;
    public GameObject gunGenerator;
    private RaycastHit hit;    

    private float xAxisClamp;

    public bool playerShot;
    public float hitDistance;
    public float maxDeviation;
    public float range; //Affects accuracy cone size directly - the bigger the number, the smaller the deviation
    public LineRenderer lineRenderer;
    Vector3[] linePosition = new Vector3[2];
    public GameObject lineDestroyer;

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

        maxDeviation = 1 - (gunGenerator.GetComponent<GunGenerator>().accuracy / 100);     //Size of accuracy cone
        if (maxDeviation < 0.1f) {
            maxDeviation = 0.1f;
        } else if (maxDeviation > 0.8f) {
            maxDeviation = 0.8f;
        }

        CameraRotation();
        LockCursor();

        if (!GameObject.Find("LineDestroyer(Clone)")) {
            linePosition[0] = transform.position;
            linePosition[1] = transform.position;
            lineRenderer.SetPositions(linePosition);
        }

        if (playerShot) {
            hit.transform.gameObject.GetComponent<TestDummy>().health -= gunHolder.GetComponent<GunHolderController>().damage;
            Debug.Log(hit.transform.name + " was hit, deducting " + gunHolder.GetComponent<GunHolderController>().damage + " from enemy health"); //Deduct health from target
        }        

        Vector3 deviation3D = Random.insideUnitCircle * maxDeviation;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward * range + deviation3D);    //*Accuracy calculations
        Vector3 fwd = transform.rotation * rot * Vector3.forward;

        if (Physics.Raycast(transform.position, fwd, out hit, 500)) {
            Debug.DrawRay(transform.position, fwd * 1000f, Color.green, 2);
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == false) {  //SEMI-AUTO
                if (Input.GetKeyDown(KeyCode.Mouse0) && gunHolder.GetComponent<GunHolderController>().readyToFire) {
                    DrawLine();
                    if (hit.transform.tag == "Player") {
                        playerShot = true;
                        Debug.DrawRay(transform.position, fwd * 1000f, Color.red, 2);
                        DrawLine();
                        hitDistance = hit.distance;
                    }
                }
                else {
                    playerShot = false;
                }
            } else {                                                           
                if (Input.GetKey(KeyCode.Mouse0) && gunHolder.GetComponent<GunHolderController>().readyToFire) {     //FULL-AUTO
                    DrawLine();
                    if (hit.transform.tag == "Player") {
                        playerShot = true;
                        Debug.DrawRay(transform.position, fwd * 1000f, Color.red, 2);
                        DrawLine();
                        hitDistance = hit.distance;
                    }
                }
                else {
                    playerShot = false;
                }
            }
        }
        else {
            playerShot = false;
        }        
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
    void DrawLine() {
        Vector3 deviation3D = Random.insideUnitCircle * maxDeviation;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward * range + deviation3D);    //*Accuracy calculations
        Vector3 fwd = transform.rotation * rot * Vector3.forward;
        linePosition[0] = gunGenerator.GetComponent<GunGenerator>().barrel.transform.Find("BulletExit").transform.position; //BulletExit Gameobject of the barrel
        linePosition[1] = fwd * 100 + transform.position;
        lineRenderer.SetPositions(linePosition);
        GameObject lineDest = Instantiate(lineDestroyer, transform.position, transform.rotation) as GameObject;
        Destroy(lineDest, 0.5f);
    }
}
