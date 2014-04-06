using UnityEngine;
using System.Collections;

public class DrawController : MonoBehaviour {
	public static float LeftWall, RightWall, UpperWall, DownWall, xscale, yscale;
	public static float LeftWallS =0.02f, UpperWallS = 0.7f, RightWallS=0.98f, DownWallS=0.02f, ratio = (float)Screen.width/ (float)Screen.height, scale = 0.01f;

	void CreatePoll ( float x, float y, float W, float H  ) {
		Vector3 tmp = new Vector3( x + W/2, y + H/2, 0 );
		tmp = GameObject.Find ("MainCamera").camera.ScreenToWorldPoint (tmp);
		tmp = new Vector3 (tmp.x, tmp.y, 0f);

		W /= Screen.width; W *= 16 * ratio;
		H /= Screen.height; H *= 16;
		GameObject d = Instantiate (Resources.Load ("Wall"), tmp, Quaternion.Euler (0, 0, 0f)) as GameObject;
		d.transform.localScale = new Vector3 (W / 2, H / 2, 10f); 
	}
	
	// Update is called once per frame
	void Awake () {
		UpperWall = UpperWallS * Screen.height; DownWall = DownWallS * Screen.height;
		LeftWall = LeftWallS * Screen.width; RightWall = RightWallS * Screen.width;
		xscale = scale * Screen.width; yscale = scale * Screen.height * ratio; 

		CreatePoll (LeftWall - xscale, DownWall - yscale, xscale, UpperWall - DownWall + 2 * yscale);
		CreatePoll (LeftWall - xscale, UpperWall, RightWall - LeftWall + 2 * xscale, yscale);
		CreatePoll (RightWall, DownWall - yscale, xscale, UpperWall - DownWall + 2 * yscale);
		CreatePoll (LeftWall - xscale, DownWall - yscale, RightWall - LeftWall + 2 * xscale, yscale);
	}
}
