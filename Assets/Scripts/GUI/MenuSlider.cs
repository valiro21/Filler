using UnityEngine;
using System.Collections;

public class MenuSlider : MonoBehaviour {
	public static bool selected = false;

	void OnMouseExit () {
		selected = false;
	}

	void OnMouseEnter () {
		selected = true;
	}

	void LateUpdate () {
		if ( selected == false ) {
			GUIController.MenuButton.SetActive (true);
			GUIController.Dropdown.SetActive (false);
		}
	}
}
