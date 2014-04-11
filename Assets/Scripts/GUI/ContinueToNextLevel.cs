using UnityEngine;
using System.Collections;

public class ContinueToNextLevel : MonoBehaviour {

	void Starte () {
		GameController.StartNextLevel ();
	}

	void OnMouseDown () {
		Invoke ("Starte", 0.1f);
	}

}
