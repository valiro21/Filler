using UnityEngine;
using System.Collections;

public class Ins34 : MonoBehaviour {

	void OnMouseDown () {
		GUIController.Ins3.SetActive (false);
		GUIController.Ins4.SetActive (true);
	}
}
