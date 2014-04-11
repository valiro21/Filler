using UnityEngine;
using System.Collections;

public class PauseUnpause : MonoBehaviour {

	void OnMouseDown () {
		if ( !GameController.Ins )
			if ( GameController.Paused )
				GameController.Resume ();
			else {
				GUIController.GP.SetActive(true);
				GameController.Pause();
		}
	}
}
