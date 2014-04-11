using UnityEngine;
using System.Collections;

public class CompletionBonus : MonoBehaviour {
	public static int bonus;
	
	// Update is called once per frame
	void Update () {
		bonus = Mathf.Max (0, Mathf.RoundToInt (((GameController.cleared - 66.6f) * (GameController.level + 5)) * 4));
		GetComponent<TextMesh> ().text = bonus.ToString ();
	}
}
