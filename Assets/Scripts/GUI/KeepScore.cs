using UnityEngine;
using System.Collections;

public class KeepScore : MonoBehaviour {
	
	void Update () {
		GetComponent<TextMesh> ().text = "Score:  " + GameController.score.ToString ();
	}
}
