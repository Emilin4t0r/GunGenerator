using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

	public Slider slider;
	public Image filler;

	void Start() {
	}

	void Update() {

		if (slider.value < 10) {
			filler.color = new Color32(200, 80, 0, 255);
		} else if (slider.value < 20) {
			filler.color = new Color32(200, 100, 0, 255);
		} else if (slider.value < 30) {
			filler.color = new Color32(200, 120, 0, 255);
		} else if (slider.value < 40) {
			filler.color = new Color32(200, 140, 0, 255);
		} else if (slider.value < 50) {
			filler.color = new Color32(200, 160, 0, 255);
		} else if (slider.value < 60) {
			filler.color = new Color32(200, 180, 0, 255);
		} else if (slider.value < 70) {
			filler.color = new Color32(200, 200, 0, 255);
		} else if (slider.value < 80) {
			filler.color = new Color32(200, 220, 0, 255);
		} else if (slider.value < 90) {
			filler.color = new Color32(200, 240, 0, 255);
		} else if (slider.value <= 100) {
			filler.color = new Color32(200, 255, 0, 255);
		}
	}
}
