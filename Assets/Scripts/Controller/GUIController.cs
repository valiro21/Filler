using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	static GUIText level, lives, score, cleared, balls, timeleft;

	// Use this for initialization
	void Start () {
		level = GameObject.Find ("Level").GetComponent<GUIText>();
		lives = GameObject.Find ("Lives").GetComponent<GUIText>();
		score = GameObject.Find ("Score").GetComponent<GUIText>();
		balls = GameObject.Find ("Balls").GetComponent<GUIText>();
		cleared = GameObject.Find ("Cleared").GetComponent<GUIText>();
		timeleft = GameObject.Find ("Time left").GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
		level.text = "Level: " + GameController.level.ToString();
		balls.text = "Balls: " + GameController.balls.ToString();
		score.text = "Score: " + GameController.score.ToString();
		cleared.text = GameController.cleared.ToString ("f1") + "% cleared";
		lives.text = "Lives: " + GameController.HP.ToString ();
		timeleft.text = "Time left: " + GameController.timeleft.ToString();
	}
}
