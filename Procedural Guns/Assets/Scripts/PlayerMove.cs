using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public string horizontalInputName;
    public string verticalInputName;
    public float movementSpeed;

    public float slopeForce;
    public float sfRayLength;

    private CharacterController charController;
    private Camera camera;

    //public Animator anim;

    public AnimationCurve jumpFalloff;
    public float jumpMultiplier;
    public KeyCode jumpKey;

    public bool isJumping;


    private void Awake() {
        charController = GetComponent<CharacterController>();
        camera = GetComponentInChildren<Camera>();
    }

    private void Update() {
        PlayerMovement();
    }

    private void PlayerMovement() {

        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        //if ((vertInput != 0 || horizInput != 0)) {
        //     anim.Play("Bobbing");
        // }

        if ((vertInput != 0 || horizInput != 0) && OnSlope()) {  //if moving AND on slope
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
        }

        JumpInput();
        SprintInput();
    }

    private bool OnSlope() {
        if (isJumping) {
            return false;
        }
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * sfRayLength)) {
            if (hit.normal != Vector3.up) {
                return true;
            }
        }
        return false;
    }

    private void JumpInput() {
        if (Input.GetKeyDown(jumpKey) && !isJumping) {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private void SprintInput() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            movementSpeed += 6;
            camera.fieldOfView += 8;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            movementSpeed -= 6;
            camera.fieldOfView -= 8;
        }
    }

    private IEnumerator JumpEvent() {
        charController.slopeLimit = 90.0f; //tämä estää glitchauksen seinää vasten hypätessä
        float timeInAir = 0.0f;

        do {
            float jumpForce = jumpFalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
            // anim.Play("Jumping");

        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}

