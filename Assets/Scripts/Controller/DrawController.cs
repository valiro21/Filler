using UnityEngine;
using System.Collections;

public class DrawController : MonoBehaviour {
	public static float LeftWall, RightWall, UpperWall, DownWall, xscale, yscale;
	public static float LeftWallS =0.02f, UpperWallS = 0.78f, RightWallS=0.98f, DownWallS=0.02f, ratio = (float)Screen.width/ (float)Screen.height, scale = 0.01f;
	public static float Width, Heigth, Area;
	public static GameObject Background;

	void NormalColor () {
		Background.renderer.material.color = new Color ( 116f/255f, 116f/255f, 116f/255f, 5f/255f );
	}

	public static void NormaliseColor () {
		GameObject.Find ( "God" ).GetComponent<DrawController>().Invoke ( "NormalColor", 0.2f);
	}

	GameObject CreatePoll ( float x, float y, float W, float H, float ZOff  ) {
		Vector3 tmp = new Vector3( x + W/2, y + H/2, 0 );
		tmp = GameObject.Find ("MainCamera").camera.ScreenToWorldPoint (tmp);
		tmp = new Vector3 (tmp.x, tmp.y, ZOff);

		W /= Screen.width; W *= 16 * ratio;
		H /= Screen.height; H *= 16;
		GameObject d = Instantiate (Resources.Load ("Wall"), tmp, Quaternion.Euler (0, 0, 0f)) as GameObject;
		d.transform.localScale = new Vector3 (W / 2, H / 2, 10f);

		return d;
	}
	
	// Update is called once per frame
	void Awake () {
		UpperWall = UpperWallS * Screen.height; DownWall = DownWallS * Screen.height;
		LeftWall = LeftWallS * Screen.width; RightWall = RightWallS * Screen.width;
		Width = RightWall - LeftWall; Heigth = UpperWall - DownWall;
		Area = Width * Heigth;
		xscale = scale * Screen.width; yscale = scale * Screen.height * ratio; 

		CreatePoll (LeftWall - xscale, DownWall - yscale, xscale, UpperWall - DownWall + 2 * yscale, 0);
		CreatePoll (LeftWall - xscale, UpperWall, RightWall - LeftWall + 2 * xscale, yscale, 0);
		CreatePoll (RightWall, DownWall - yscale, xscale, UpperWall - DownWall + 2 * yscale, 0);
		CreatePoll (LeftWall - xscale, DownWall - yscale, RightWall - LeftWall + 2 * xscale, yscale, 0);
		Background = CreatePoll (LeftWall, DownWall, RightWall - LeftWall, UpperWall - DownWall, 40);
	}
}
