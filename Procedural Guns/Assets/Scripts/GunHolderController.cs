using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolderController : MonoBehaviour
{

    public Animator anim;
    public GameObject gunGenerator;
    public GameObject cameraHolder;
    public GameObject playerCamera;
    public bool readyToFire;

    public float fireRate;
    public float handling;
    public float damage;
    public float range;

    public float counter;
    public float maxCounter = 1;
    public float counter2;
    public float maxCounter2 = 0.2f;
    public float cameraShake;

    void Start()
    {
        //TODO:
        //MAKE AMMO-INT TO GUNGENERATOR AND RELOAD BOOL&ANIM HERE   
    }

    void Update() {

        fireRate = gunGenerator.GetComponent<GunGenerator>().fireRate / 10;
        handling = (0.1f - (gunGenerator.GetComponent<GunGenerator>().handling / 1000)) * 4;
        damage = gunGenerator.GetComponent<GunGenerator>().power;
        range = gunGenerator.GetComponent<GunGenerator>().range;

        damage += (range - playerCamera.GetComponent<PlayerLook>().hitDistance); //Calculate damage modifier by subtracting bullet distance from range
        damage = damage / 2;
        if (damage < 1) 
            damage = 1;        

        if (counter >= maxCounter) {
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == false) { //Semi-Auto
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    anim.SetBool("Shoot", true);
                    readyToFire = true;
                    counter = 0;
                    counter2 = 0;
                }
            }
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == true) { //Full-Auto
                if (Input.GetKey(KeyCode.Mouse0)) {
                    anim.SetBool("Shoot", true);
                    readyToFire = true;
                    counter = 0;
                    counter2 = 0;
                }
            }
        } else {
            counter += Time.deltaTime * fireRate;
            anim.SetBool("Shoot", false);
            readyToFire = false;
        }        

        if (readyToFire) {
            cameraShake = handling;
        } else {
            if (counter2 >= maxCounter2) {
                cameraShake = 0;
                counter2 = 0;
            }
            else {
                counter2 += Time.deltaTime;
            }
        }

        //CAMERA SHAKE
        if (cameraShake > 0) {
            cameraHolder.transform.localPosition = Random.insideUnitSphere * cameraShake;
        } else {
            cameraHolder.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
