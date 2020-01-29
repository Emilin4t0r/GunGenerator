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

    public AudioSource gunSound;
    public AudioSource sfxReload;
    public bool sfxReloadisPlaying;

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

        if (currentAmmo == 0 && transform.childCount > 0 && !Input.GetKey(KeyCode.LeftShift)) {
            reloading = true;        
        }
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !Input.GetKey(KeyCode.LeftShift)) {            
            reloading = true;
        }
        if (reloading) {
            if (!sfxReloadisPlaying) {
                sfxReload.Play();
                sfxReloadisPlaying = true;
            }
            anim.SetBool("Reloading", true);
            if (counter3 >= maxCounter3) {
                anim.SetBool("Reloading", false);
                ammoCounter = 0;
                counter3 = 0;
                reloading = false;
                sfxReloadisPlaying = false;
            } else {
                counter3 += Time.deltaTime;                
            }
        }

        if (damage > 50)
            damage = damage / 2;        
        damage += (range - playerCamera.GetComponent<PlayerLook>().hitDistance); //Calculate damage modifier by subtracting bullet distance from range 
        if (damage < 5)
            damage = 5;

        if (counter >= maxCounter) {
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == false) { //Semi-Auto
                if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading && !Input.GetKey(KeyCode.LeftShift)) {
                    anim.SetBool("Shoot", true);
                    anim.SetTrigger("Shooty");
                    gunSound.Play();
                    readyToFire = true;
                    ammoCounter++;
                    counter = 0;
                    counter2 = 0;
                }
            }
            if (gunGenerator.GetComponent<GunGenerator>().fullAuto == true) { //Full-Auto
                if (Input.GetKey(KeyCode.Mouse0) && !reloading && !Input.GetKey(KeyCode.LeftShift)) {
                    anim.SetBool("Shoot", true);
                    anim.SetTrigger("Shooty");
                    gunSound.Play();
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

        if (Input.GetKey(KeyCode.LeftShift)) {
            anim.SetBool("Running", true);
        } else {
            anim.SetBool("Running", false);
        }

        //CAMERA SHAKE
        if (cameraShake > 0) {
            cameraHolder.transform.localPosition = Random.insideUnitSphere * cameraShake;
        } else {
            cameraHolder.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
