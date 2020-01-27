using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunHolderController : MonoBehaviour
{

    public Animator anim;
    public GameObject gunGenerator;
    public GameObject cameraHolder;
    public GameObject playerCamera;
    public bool readyToFire;
    public bool reloading;

    public float fireRate;
    public float handling;
    public float damage;
    public float range;
    public int maxAmmo;
    public int currentAmmo;
    public Text currentAmmoText;
    public int ammoCounter;

    public float counter;
    public float maxCounter = 1;
    public float counter2;
    public float maxCounter2 = 0.2f;
    public float counter3;
    public float maxCounter3 = 1;
    public float cameraShake;

    void Start()
    {
        //TODO:
        //IMPLEMENT SOUNDS FOR EVERY RECEIVER
    }

    void Update() {

        fireRate = gunGenerator.GetComponent<GunGenerator>().fireRate / 10;
        handling = (0.1f - (gunGenerator.GetComponent<GunGenerator>().handling / 1000)) * 4;
        damage = gunGenerator.GetComponent<GunGenerator>().power;
        range = gunGenerator.GetComponent<GunGenerator>().range;
        maxAmmo = gunGenerator.GetComponent<GunGenerator>().ammo;
        currentAmmo = maxAmmo - ammoCounter;
        currentAmmoText.text = currentAmmo.ToString();

        if (currentAmmo == 0 && transform.childCount > 0) {
            reloading = true;        
        }
        if (Input.GetKey(KeyCode.R) && currentAmmo < maxAmmo) {
            reloading = true;
        }
        if (reloading) {
            anim.SetBool("Reloading", true);
            if (counter3 >= maxCounter3) {
                anim.SetBool("Reloading", false);
                ammoCounter = 0;
                counter3 = 0;
                reloading = false;                
            } else {
                counter3 += Time.deltaTime;                
            }
        }

        damage += (range - playerCamera.GetComponent<PlayerLook>().hitDistance); //Calculate damage modifier by subtracting bullet distance from range
        damage = damage / 2;
        if (damage < 1) 
            damage = 1;        

        if (counter >= maxCounter) {
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == false) { //Semi-Auto
                if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading) {
                    anim.SetBool("Shoot", true);
                    anim.SetTrigger("Shooty");
                    readyToFire = true;
                    ammoCounter++;
                    counter = 0;
                    counter2 = 0;
                }
            }
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == true) { //Full-Auto
                if (Input.GetKey(KeyCode.Mouse0) && !reloading) {
                    anim.SetBool("Shoot", true);
                    anim.SetTrigger("Shooty");
                    readyToFire = true;
                    ammoCounter++;
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
