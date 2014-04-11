using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static float MovementForce = 120f;
	public static Vector3 nullVector = new Vector3 ( 1000f, 1000f, 1000f );
	static GameObject x;
	static Vector3 tmp, ptmp = nullVector;
	public static bool Paused, Ins = false;
	public static float UpperWall, LeftWall, DownWall, RightWall;
	static float T, PT;
	public static int level, balls, timeleft, score, HP, bullets;
	public static float cleared;

	public static void Pause () {
		if ( !Paused ) {
			Paused = true;
			PauseBalls ();
			ptmp = tmp = nullVector;
			DrawController.Background.renderer.material.color = new Color ( 60f/255f, 60f/255f, 60f/255f, 5f/255f );
			PauseBullets ();
		}
	}

	public static void Resume () {
		Paused = false;
		DrawController.NormaliseColor ();
		GUIController.GP.SetActive(false);
		ResumeBalls ();
		ResumeBullets ();
		PT = Time.time;
	}

	static void CalculateScore () {
		score += balls * 5;
		score += HP * 25;
		score += timeleft / 10;
		score += Mathf.Max (0, Mathf.RoundToInt (((cleared - 66.6f) * (level + 5)) * 4));
	}

	public void GameOver () {
		Pause ();
		AudioController.GameOver ();
		GUIController.GameOverGUI.SetActive (true);
	}

	public static void LoseHP () {
		AudioController.Damage ();
		if ( HP == 1 ) {
			HP--;
			GameObject.Find ("God").GetComponent<GameController>().Invoke ( "GameOver", 0.1f );
		}
		else {
			DrawController.Background.renderer.material.color = Color.red;
			DrawController.NormaliseColor ();
			HP--;
		}
	}

	public static void RecreateBullets ( long number ) {
		for ( long i = 1 ;i <= number; i++ ) {
			Instantiate ( Resources.Load ("Bullet"), new Vector3 (Random.Range (LeftWall, RightWall), Random.Range (DownWall, UpperWall), 0f), Quaternion.Euler ( 0, 0, 0 ) );
		}
	}

	static void UnfreezeBalls () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject i in x)
			i.GetComponent<TempPlayerBehavior>().Unfreeze ();
	}

	static void PauseBalls () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject i in x)
			if ( i.GetComponent<TempPlayerBehavior>() != null )
				i.GetComponent<TempPlayerBehavior>().Pause ();
	}
	
	static void PauseBullets () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject i in x)
			i.GetComponent<EnemyMovement>().Pause ();
	}

	static void ResumeBalls () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject i in x)
			i.GetComponent<TempPlayerBehavior>().Resume ();
	}
	
	static void ResumeBullets () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject i in x)
			i.GetComponent<EnemyMovement>().Resume ();
	}

	public static void DestroyBalls () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject i in x)
			Destroy ( i );
	}

	public static void DestroyBullets () {
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject i in x)
			Destroy ( i );
	}

	public static void StartLevel ( int lvl ) {
		level = lvl;
		HP = lvl + 1;
		balls = 20 + (lvl - 1) * 2;
		timeleft = 900 + (lvl - 1) * 300;
		cleared = 0;
		bullets = lvl + 1;

		DestroyBalls ();
		DestroyBullets ();
		RecreateBullets (bullets);
		Paused = false;
	}

	public static void StartNextLevel () {
		GameObject.Find ("LevelCompleteGUI").SetActive ( false );
		DrawController.Background.renderer.material.color = new Color ( 116f/255f, 116f/255f, 116f/255f, 5f/255f );
		GUIController.GP.SetActive(false);
		StartLevel (level + 1);
	}

	public static void StartOver () {
		score = 0;
		AudioController.StartGameMusic ();
		DrawController.Background.renderer.material.color = new Color ( 116f/255f, 116f/255f, 116f/255f, 5f/255f );
		GUIController.GP.SetActive(false);
		Ins = false;
		StartLevel (1);
		PT = Time.time;
	}

	public static Vector3 ScreenToWorld( Vector3 pos ) {
		pos = GameObject.Find ("MainCamera").camera.ScreenToWorldPoint ( pos );
		return new Vector3 (pos.x, pos.y, 0);
	}

	public static float ScreenToWorld( float val, bool vertical ) {
		Vector3 pos;
		if ( vertical ) {
			pos = GameObject.Find ("MainCamera").camera.ScreenToWorldPoint ( new Vector3 (0f, val, 0f) );
			return pos.y;
		}
		else {
			pos = GameObject.Find ("MainCamera").camera.ScreenToWorldPoint ( new Vector3 (val, 0f, 0f) );
			return pos.x;
		}
	}

	public static void CheckCompletion () {
		if (cleared >= 66.6f) {
			Pause ();
			CalculateScore ();
			AudioController.LevelComplete ();
			GUIController.LevelCompleteGUI.SetActive ( true );
		}
	}

	public static void DestroyCurrentBall () {
		Destroy (x);
		x = null;
	}

	public static void CreateBall () {
		if (balls == 0)
			LoseHP ();
		else
			balls--;
		if ( !Paused )
			x = Instantiate ( Resources.Load ( "Ball"), tmp, Quaternion.Euler ( 0, 0, 0 ) ) as GameObject;
	}
	
	void Update () {

		if ( !Paused ) {
			if ( timeleft > 0 ) {
				T = Time.time;
				if ( T - PT > 0.1 ) {
					timeleft--;
					PT = T;
				}
			}

			tmp = InputController.GetInput ();
			if ( tmp != nullVector && ptmp == nullVector ) {
				CreateBall ();
			}
			else if ( x != null && tmp == nullVector && ptmp != nullVector )
				x.GetComponent<TempPlayerBehavior>().Unfreeze ();
			ptmp = tmp;
		}
	}

	void Start () {
		UpperWall = ScreenToWorld ( DrawController.UpperWall, true );
		DownWall = ScreenToWorld (DrawController.DownWall, true);
		LeftWall = ScreenToWorld ( DrawController.LeftWall, false );
		RightWall = ScreenToWorld (DrawController.RightWall, false);

		StartOver ();
	}
}
