using UnityEngine;
using System.Collections;

public class Ins12 : MonoBehaviour {

	void OnMouseDown () {
		GUIController.Ins1.SetActive (false);
		GUIController.Ins2.SetActive (true);
	}
}
