using UnityEngine;
using System.Collections;

public class MuteUnmuteMusic : MonoBehaviour {

	void OnMouseDown () {
		if (AudioPool.IsBackgroundMusicMute () )
			AudioPool.UnmuteBackgroundMusic ();
		else
			AudioPool.MuteBackgroundMusic ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (AudioPool.IsBackgroundMusicMute ())
			transform.FindChild("ButtonText").GetComponent<TextMesh>().text = "Music On";
		else
			transform.FindChild("ButtonText").GetComponent<TextMesh>().text = "Music Off";
	}
}
