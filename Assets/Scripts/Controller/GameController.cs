using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static Vector3 nullVector = new Vector3 ( 1000f, 1000f, 1000f );
	static GameObject x;
	static Vector3 tmp, ptmp = nullVector;
	public static float UpperWall, LeftWall, DownWall, RightWall;

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
	
	void Update () {
		tmp = InputController.GetInput ();
		if ( tmp != nullVector && ptmp == nullVector )
			x = Instantiate ( Resources.Load ( "Ball"), tmp, Quaternion.Euler ( 0, 0, 0 ) ) as GameObject;
		else if ( tmp == nullVector && ptmp != nullVector )
			x.GetComponent<TempPlayerBehavior>().Unfreeze ();
		ptmp = tmp;
	}

	void Start () {
		UpperWall = ScreenToWorld ( DrawController.UpperWall, true );
		DownWall = ScreenToWorld (DrawController.DownWall, true);
		LeftWall = ScreenToWorld ( DrawController.LeftWall, false );
		RightWall = ScreenToWorld (DrawController.RightWall, false);
	}
}
