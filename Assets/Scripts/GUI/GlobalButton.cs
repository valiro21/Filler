using UnityEngine;
using System.Collections;

public class GlobalButton : MonoBehaviour {

	void OnMouseEnter () {
		AudioController.Select ();
		renderer.material.color = new Color( 116f/255f, 116f/255f, 116f/255f);
	}

	void OnMouseExit () {
		renderer.material.color = new Color( 182f/255f, 182f/255f, 182f/255f);
	}
}
