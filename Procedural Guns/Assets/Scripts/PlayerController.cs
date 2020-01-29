using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Animator cameraAnim;
    public bool moving;

    private void Update() {       

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            cameraAnim.SetBool("Moving", true);
            moving = true;
        }
        else {
            cameraAnim.SetBool("Moving", false);
            moving = false;
        }
        if (Input.GetKey(KeyCode.Space)) {
            cameraAnim.SetBool("Moving", false);
        }        
    }
}
