using UnityEngine;
using System.Collections;

public class TimeBonus : MonoBehaviour {
	public static int bonus;
	
	// Update is called once per frame
	void Update () {
		bonus = GameController.timeleft /10;
		GetComponent<TextMesh> ().text = bonus.ToString ();
	}
}
