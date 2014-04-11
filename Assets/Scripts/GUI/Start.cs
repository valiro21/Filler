using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

	void StartG () {
		GUIController.Ins1.SetActive (false);
		GUIController.Ins2.SetActive (false);
		GUIController.Ins3.SetActive (false);
		GUIController.Ins4.SetActive (false);
		GUIController.GameOverGUI.SetActive (false);
		GameController.StartOver ();
	}

	void OnMouseDown () {
		Invoke ("StartG", 0.1f);
	}
}
