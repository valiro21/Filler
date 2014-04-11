using UnityEngine;
using System.Collections;

public class Ins23 : MonoBehaviour {

	void OnMouseDown () {
		GUIController.Ins2.SetActive (false);
		GUIController.Ins3.SetActive (true);
	}
}
