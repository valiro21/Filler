using UnityEngine;
using System.Collections;

public class MenuDrop : MonoBehaviour {

	void OnMouseEnter () {
		GUIController.Dropdown.SetActive (true);
		GUIController.MenuButton.SetActive (false);
		MenuSlider.selected = true;
	}
}
