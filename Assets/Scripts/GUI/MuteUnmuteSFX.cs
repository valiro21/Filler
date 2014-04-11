using UnityEngine;
using System.Collections;

public class MuteUnmuteSFX : MonoBehaviour {

	void OnMouseDown () {
		if (AudioPool.IsSFXMute () )
			AudioPool.UnmuteSFX ();
		else
			AudioPool.MuteSFX ();

	}
	
	// Update is called once per frame
	void Update () {
		if (AudioPool.IsSFXMute ())
			transform.FindChild("ButtonText").GetComponent<TextMesh>().text = "SFX On";
		else
			transform.FindChild("ButtonText").GetComponent<TextMesh>().text = "SFX Off";
	}
}
