using UnityEngine;
using System.Collections;

public class BallsLeftBonus : MonoBehaviour {
	public static int bonus;
	
	// Update is called once per frame
	void Update () {
		bonus = GameController.balls * 5;
		GetComponent<TextMesh> ().text = bonus.ToString ();
	}
}
