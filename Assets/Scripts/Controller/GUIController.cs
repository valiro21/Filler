using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	static GUIText level, lives, score, cleared, balls, timeleft;
	public static GameObject Ins1, Ins2, Ins3, Ins4, GameOverGUI, LevelCompleteGUI, Dropdown, MenuButton, GP;

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

	void Awake () {
		Ins1 = GameObject.Find ("Instruction1");
		Ins2 = GameObject.Find ("Instruction2");
		Ins3 = GameObject.Find ("Instruction3");
		Ins4 = GameObject.Find ("Instruction4");
		GameOverGUI = GameObject.Find ("GameOverGUI");
		LevelCompleteGUI = GameObject.Find ("LevelCompleteGUI");
		Dropdown = GameObject.Find ("Dropdown");
		MenuButton = GameObject.Find ("MenuButton");
		GP = GameObject.Find ("GamePaused");

		Ins1.SetActive (false); Ins2.SetActive (false);
		Ins3.SetActive (false); Ins4.SetActive (false);
		GameOverGUI.SetActive (false); LevelCompleteGUI.SetActive (false);
		Dropdown.SetActive (false); MenuButton.SetActive (true);
		GP.SetActive (false);
	}
}
