using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunGenerator : MonoBehaviour {

	public GameObject[] receivers = new GameObject[3];
	public GameObject[] grips = new GameObject[3];
	public GameObject[] barrels = new GameObject[4];
	public GameObject[] magasines = new GameObject[5];
	public GameObject[] sights = new GameObject[3];
	public GameObject[] attachments = new GameObject[8];

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

	public void GenerateGun() {

		if (GameObject.Find("Receiver(Clone)") != null) {
			Destroy(GameObject.Find("Receiver(Clone)").gameObject);
		} else if (GameObject.Find("Receiver 1(Clone)") != null) {
			Destroy(GameObject.Find("Receiver 1(Clone)"));
		} else if (GameObject.Find("Receiver 2(Clone)") != null) {
			Destroy(GameObject.Find("Receiver 2(Clone)"));
		}

		int receiverNmbr = Random.Range(3, 0);
		int gripNmbr = Random.Range(3, 0);
		int barrelNmbr = Random.Range(4, 0);
		int magasineNmbr = Random.Range(5, 0);
		int sightNmbr = Random.Range(3, 0);
		int attachmentNmbr = Random.Range(8, 0);

		GameObject grey = Instantiate(receivers[receiverNmbr - 1], transform.position, Quaternion.identity) as GameObject;
		GameObject grip = Instantiate(grips[gripNmbr - 1], grey.transform.Find("GripPoint").transform.position, Quaternion.identity, grey.transform);
		GameObject barrel = Instantiate(barrels[barrelNmbr - 1], grey.transform.Find("BarrelPoint").transform.position, Quaternion.identity, grey.transform);
		GameObject magasine = Instantiate(magasines[magasineNmbr - 1], grey.transform.Find("MagasinePoint").transform.position, Quaternion.identity, grey.transform);
		GameObject sight = Instantiate(sights[sightNmbr - 1], grey.transform.Find("SightPoint").transform.position, Quaternion.identity, grey.transform);
		if (attachmentNmbr >= 7) {
			GameObject attachment = Instantiate(attachments[attachmentNmbr - 1], barrel.transform.Find("AttachmentPoint").transform.position, Quaternion.identity, grey.transform);
		} else {
			GameObject attachment = Instantiate(attachments[attachmentNmbr - 1], grey.transform.Find("AttachmentPoint").transform.position, Quaternion.identity, grey.transform);
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
				fireRate += 10;
				handling -= 10;
				break;
			case 2:
				gunNameText += "Bolt-Action ";
				accuracy += 20;
				fireRate -= 30;
				power += 10;
				break;
			case 3:
				gunNameText += "Automatic ";
				fireRate += 20;
				handling += 10;
				power += 5;
				break;
		}
		switch (attachmentNmbr) {
			case 1:
				if (randName1 == 1) {
					gunNameText += "Stable ";
				}
				accuracy += 10;
				handling += 10;
				break;
			case 2:
				break;
			case 3:
				if (randName1 == 1) {
					gunNameText += "Breaching ";
				}
				accuracy -= 10;
				power += 30;
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
				break;
			case 6:
				randName1 = 2;
				break;
			case 7:
				if (randName1 == 1) {
					gunNameText += "Attack ";
				}
				accuracy -= 10;
				range -= 5;
				handling -= 10;
				power += 20;
				break;
			case 8:
				if (randName1 == 1) {
					gunNameText += "Deployable ";
					accuracy += 20;
					handling += 30;
				}
				break;
		}
		switch (magasineNmbr) {
			case 1:
				if (randName1 == 2) {
					gunNameText += "Military ";
				}
				power += 5;
				break;
			case 2:
				if (randName1 == 2) {
					gunNameText += "High-Capacity ";
				}
				accuracy -= 10;
				handling += 20;
				power += 10;
				break;
			case 3:
				if (randName1 == 2) {
					gunNameText += "Sub-";
				}
				accuracy -= 10;
				range -= 10;
				fireRate += 10;
				handling += 20;
				power -= 10;
				break;
			case 4:
				if (randName1 == 2) {
					gunNameText += "Antique ";
				}
				accuracy -= 5;
				handling -= 10;
				power += 10;
				break;
			case 5:
				if (randName1 == 2) {
					gunNameText += "Super-";
				}
				range += 10;
				power += 10;
				power += 5;
				break;
		}
		switch (barrelNmbr) {
			case 1:
				gunNameText += "Short ";
				accuracy -= 10;
				range -= 10;
				handling += 10;
				break;
			case 2:
				gunNameText += "Battle ";
				accuracy += 20;
				range += 20;
				fireRate -= 20;
				power += 10;
				break;
			case 3:
				gunNameText += "Assault ";
				accuracy += 15;
				range += 15;
				fireRate += 15;
				handling += 10;
				power += 5;
				break;
			case 4:
				gunNameText += "Dual ";
				accuracy -= 20;
				range -= 20;
				fireRate -= 10;
				handling -= 20;
				power += 20;
				break;
		}
		switch (sightNmbr) {
			case 1:
				gunNameText += "Marksman ";
				accuracy += 10;
				range += 10;
				handling -= 10;
				break;
			case 2:
				gunNameText += "Combat ";
				accuracy += 10;
				handling += 10;
				break;
			case 3:
				break;
		}
		switch (gripNmbr) {
			case 1:
				gunNameText += "Pistol";
				accuracy -= 10;
				range -= 10;
				fireRate += 10;
				handling -= 20;
				power -= 20;
				break;
			case 2:
				gunNameText += "Rifle";
				accuracy += 20;
				range += 20;
				fireRate += 15;
				handling += 20;
				power += 20;
				break;
			case 3:
				gunNameText += "Carbine";
				accuracy += 15;
				fireRate += 20;
				handling -= 15;
				power += 10;
				break;
		}




		accSlider.value = accuracy;
		ranSlider.value = range;
		firSlider.value = fireRate;
		hanSlider.value = handling;
		powSlider.value = power;

		gunName.text = gunNameText;
		GameObject.Find("CameraRotator").GetComponent<CameraRotator>().startSpinning = false;
		GameObject.Find("CameraRotator").GetComponent<CameraRotator>().counter = 0;
		GameObject.Find("CameraRotator").transform.rotation = Quaternion.Euler(0, 50, 0);


	}
}
