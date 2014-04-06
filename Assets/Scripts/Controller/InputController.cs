using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {



	// Use this for initialization
	public static Vector3 TouchInput ( ) {
		Touch tscr;
		for ( int i = 0; i < Input.touchCount; i++ ) {
			tscr =  Input.GetTouch ( i );
			if ( tscr.position.x > DrawController.LeftWall  && tscr.position.x < DrawController.RightWall &&
			    tscr.position.y > DrawController.DownWall && tscr.position.y < DrawController.UpperWall )
				return GameController.ScreenToWorld ( new Vector3 ( tscr.position.x, tscr.position.y, 0 ) );
		}
		
		return GameController.nullVector;
	}

	static Vector3 MouseInput () {
		Vector3 tscr;
		if (Input.GetMouseButton (0)) {
			tscr = Input.mousePosition;
			if ( tscr.x > DrawController.LeftWall  && tscr.x < DrawController.RightWall &&
			    tscr.y > DrawController.DownWall && tscr.y < DrawController.UpperWall )
				return GameController.ScreenToWorld ( new Vector3 ( tscr.x, tscr.y, 0 ) );
		}

		return GameController.nullVector;
	}

	public static Vector3 GetInput () {
		Vector3 tmp = MouseInput ();
		if ( tmp == GameController.nullVector )
			return TouchInput ();
		return tmp;
	}
}
