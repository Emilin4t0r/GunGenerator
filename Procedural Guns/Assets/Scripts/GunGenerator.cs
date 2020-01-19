using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunGenerator : MonoBehaviour {

	public GameObject[] receivers = new GameObject[4];
	public GameObject[] grips = new GameObject[3];
	public GameObject[] barrels = new GameObject[4];
	public GameObject[] magasines = new GameObject[5];
	public GameObject[] sights = new GameObject[4];
	public GameObject[] attachments = new GameObject[8];
    public GameObject gunHolder;

	public float accuracy;
	public float range;
	public float fireRate;
	public float handling;
	public float power;
	public Slider accSlider;
	public Slider ranSlider;
	public Slider firSlider;
	public Slider hanSlider;
	public Slider powSlider;

	public Text gunName;
	public string gunNameText;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            GenerateGun();
        }
    }

    public void GenerateGun() {

        if (GameObject.Find("Receiver(Clone)") != null) {
            Destroy(GameObject.Find("Receiver(Clone)").gameObject);
        }
        else if (GameObject.Find("Receiver 1(Clone)") != null) {
            Destroy(GameObject.Find("Receiver 1(Clone)"));
        }
        else if (GameObject.Find("Receiver 2(Clone)") != null) {
            Destroy(GameObject.Find("Receiver 2(Clone)"));
        }
        else if (GameObject.Find("Receiver 3(Clone)") != null) {
            Destroy(GameObject.Find("Receiver 3(Clone)"));
        }

		int receiverNmbr = Random.Range(4, 0);
		int gripNmbr = Random.Range(3, 0);
		int barrelNmbr = Random.Range(4, 0);
		int magasineNmbr = Random.Range(5, 0);
		int sightNmbr = Random.Range(4, 0);
		int attachmentNmbr = Random.Range(8, 0);

		GameObject grey = Instantiate(receivers[receiverNmbr - 1], gunHolder.transform.position, gunHolder.transform.rotation, gunHolder.transform) as GameObject;
		GameObject grip = Instantiate(grips[gripNmbr - 1], grey.transform.Find("GripPoint").transform.position, gunHolder.transform.rotation, grey.transform);
		GameObject barrel = Instantiate(barrels[barrelNmbr - 1], grey.transform.Find("BarrelPoint").transform.position, gunHolder.transform.rotation, grey.transform);
		GameObject magasine = Instantiate(magasines[magasineNmbr - 1], grey.transform.Find("MagasinePoint").transform.position, gunHolder.transform.rotation, grey.transform);
		GameObject sight = Instantiate(sights[sightNmbr - 1], grey.transform.Find("SightPoint").transform.position, gunHolder.transform.rotation, grey.transform);
		if (attachmentNmbr >= 7) {
			GameObject attachment = Instantiate(attachments[attachmentNmbr - 1], barrel.transform.Find("AttachmentPoint").transform.position, gunHolder.transform.rotation, grey.transform);
		} else {
			GameObject attachment = Instantiate(attachments[attachmentNmbr - 1], grey.transform.Find("AttachmentPoint").transform.position, gunHolder.transform.rotation, grey.transform);
		}
		//^^BAYONET/BIPOD AT END OF BARREL^^

		accuracy = 30;
		range = 30;
		fireRate = 30;
		handling = 30;
		power = 30;

		int randName1 = Random.Range(2, 0);

		gunNameText = "";
		switch (receiverNmbr) {
			case 1:
				gunNameText += "Heavy ";                
                chgAtt(0, 0, 10, -10, 10);
                break;
			case 2:
				gunNameText += "Bolt-Action ";
                chgAtt(20, 0, -30, 0, 20);
                break;
			case 3:
				gunNameText += "Automatic ";
                chgAtt(0, 0, 20, 10, 5);
                break;
            case 4:
                gunNameText += "Modern ";
                chgAtt(10, 5, 5, 20, 5);
                break;
            }
		switch (attachmentNmbr) {
			case 1:
				if (randName1 == 1) {
					gunNameText += "Stable ";
				}
                chgAtt(10, 0, 10, 10, 0);
                break;
			case 2:
				break;
			case 3:
				if (randName1 == 1) {
					gunNameText += "Breaching ";
				}
				accuracy -= 10;
				power += 30;
                chgAtt(-10, 0, 0, 0, 30);
				break;
			case 4:
				if (randName1 == 1) {
					gunNameText += "Night-";
				}
				break;
			case 5:
				if (randName1 == 1) {
					gunNameText += "Tactical ";
				}
                chgAtt(10, 0, 0, 0, 0);
                break;
			case 6:
				randName1 = 2;
				break;
			case 7:
				if (randName1 == 1) {
					gunNameText += "Attack ";
				}
                chgAtt(-10, -5, 0, -10, 20);
                break;
			case 8:
				if (randName1 == 1) {
					gunNameText += "Deployable ";              
                }
                chgAtt(20, 0, 0, 30, 0);
                break;
		}
		switch (magasineNmbr) {
			case 1:
				if (randName1 == 2) {
					gunNameText += "Military ";
				}
                chgAtt(0, 0, 0, 0, 5);
                break;
			case 2:
				if (randName1 == 2) {
					gunNameText += "High-Capacity ";
				}
                chgAtt(-10, 0, 0, 20, 10);
                break;
			case 3:
				if (randName1 == 2) {
					gunNameText += "Sub-";
				}
                chgAtt(-10, -10, 10, 20, -10);
                break;
			case 4:
				if (randName1 == 2) {
					gunNameText += "Antique ";
				}
                chgAtt(-5, 0, 0, -10, 10);
                break;
			case 5:
				if (randName1 == 2) {
					gunNameText += "Super-";
				}
                chgAtt(0, 10, 5, 0, 10);
                break;
		}
		switch (barrelNmbr) {
			case 1:
				gunNameText += "Short ";
                chgAtt(-10, -10, 0, 10, 0);
                break;
			case 2:
				gunNameText += "Battle ";
                chgAtt(20, 20, -20, 0, 10);
                break;
			case 3:
				gunNameText += "Assault ";
                chgAtt(15, 15, 15, 10, 5);
                break;
			case 4:
				gunNameText += "Dual ";
                chgAtt(-20, -20, -10, -20, 30);
                break;
		}
		switch (sightNmbr) {
			case 1:
				gunNameText += "Marksman ";
                chgAtt(10, 10, 0, -10, 0);
                break;
			case 2:
				gunNameText += "Combat ";
                chgAtt(10, 0, 0, 10, 0);
                break;
			case 3:
				break;
            case 4:
                break;
        }
		switch (gripNmbr) {
			case 1:
				gunNameText += "Pistol";
                chgAtt(-10, -10, 10, -20, -20);
                break;
			case 2:
				gunNameText += "Rifle";
                chgAtt(20, 20, 15, 20, 20);
                break;
			case 3:
				gunNameText += "Carbine";
                chgAtt(15, 0, 20, -15, 10);
                break;
		}

        //IF ATTRIBUTE NEGATIVE --> 0
        if (accuracy < 0)
            accuracy = 0;
        if (range < 0)
            range = 0;
        if (fireRate < 0)
            fireRate = 0;
        if (handling < 0)
            handling = 0;
        if (power < 0)
            power = 0;

        //SLIDERS
		accSlider.value = accuracy;
		ranSlider.value = range;
		firSlider.value = fireRate;
		hanSlider.value = handling;
		powSlider.value = power;

		gunName.text = gunNameText;
		/*GameObject.Find("CameraRotator").GetComponent<CameraRotator>().startSpinning = false;
		GameObject.Find("CameraRotator").GetComponent<CameraRotator>().counter = 0;
		GameObject.Find("CameraRotator").transform.rotation = Quaternion.Euler(0, 50, 0);
        */
	}

    //FUNCTION FOR MODIFYING ATTRIBUTES (CHANGE ATTRIBUTES)
    void chgAtt(int acc, int ran, int fir, int han, int pow) { 
        accuracy += acc;
        range += ran;
        fireRate += fir;
        handling += han;
        power += pow;
    }
}
