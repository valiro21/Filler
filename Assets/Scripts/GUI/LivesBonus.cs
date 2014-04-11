using UnityEngine;
using System.Collections;

public class LivesBonus : MonoBehaviour {
	public static int bonus;
	
	// Update is called once per frame
	void Update () {
		bonus = GameController.HP * 25;
		GetComponent<TextMesh> ().text = bonus.ToString ();
	}
}
