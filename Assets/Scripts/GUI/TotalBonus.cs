using UnityEngine;
using System.Collections;

public class TotalBonus : MonoBehaviour {
	public static int bonus;

	// Update is called once per frame
	void Update () {
		bonus = CompletionBonus.bonus + LivesBonus.bonus + TimeBonus.bonus + BallsLeftBonus.bonus;
		GetComponent<TextMesh> ().text = bonus.ToString ();
	}
}
