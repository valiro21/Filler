using UnityEngine;
using System.Collections;

public class AudioPool : MonoBehaviour {
	
	static AudioSource BackgroundMusic, SingleSound;
	
	public static void PlayAudioClip ( AudioClip Sound ) {
		SingleSound.PlayOneShot ( Sound );
	}
	
	public static void SetBackgroundMusic ( AudioClip Sound ) {
		BackgroundMusic.Stop ( );
		BackgroundMusic.clip = Sound;
		BackgroundMusic.loop = true;
		BackgroundMusic.Play ( );
	}

	public static void UnmuteSFX () {
		SingleSound.volume = 1;
	}
	
	public static void UnmuteBackgroundMusic () {
		BackgroundMusic.volume = 1;
	}


	public static void MuteSFX () {
		SingleSound.volume = 0;
	}

	public static void MuteBackgroundMusic () {
		BackgroundMusic.volume = 0;
	}

	public static bool IsBackgroundMusicMute () {
		return BackgroundMusic.volume == 0;
	}

	public static bool IsSFXMute () {
		return SingleSound.volume == 0;
	}
	
	void Awake () {
		BackgroundMusic = gameObject.AddComponent<AudioSource>(); 
		SingleSound = gameObject.AddComponent<AudioSource>();
		
		SingleSound.volume = 1;
		BackgroundMusic.volume = 1;
	}
}