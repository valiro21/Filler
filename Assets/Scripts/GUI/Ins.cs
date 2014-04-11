using UnityEngine;
using System.Collections;

public class Ins : MonoBehaviour {

	void OnMouseDown () {
		GUIController.Ins2.SetActive (false);
		GUIController.Ins3.SetActive (false);
		GUIController.Ins4.SetActive (false);
		GUIController.GameOverGUI.SetActive (false);
		GUIController.LevelCompleteGUI.SetActive (false);
		GUIController.Ins1.SetActive (true);
		GameController.Ins = true;
		GameController.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
