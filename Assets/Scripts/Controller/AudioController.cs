using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	public static AudioClip DamageSound, GameOverSound, SelectSound, LevelCompleteSound, BackgroundMusic;
	
	public static void Damage () {
		AudioPool.PlayAudioClip ( DamageSound );
	}
	
	public static void GameOver () {
		AudioPool.PlayAudioClip (GameOverSound);
	}

	public static void LevelComplete () {
		AudioPool.PlayAudioClip (LevelCompleteSound);
	}

	public static void StartGameMusic () {
		AudioPool.SetBackgroundMusic (BackgroundMusic);
	}

	public static void Select () {
		AudioPool.PlayAudioClip (SelectSound);
	}
	
	
	void Awake () {
		GameObject ValuesGod = GameObject.Find ("ValuesGod");
		
		DamageSound = ValuesGod.GetComponent<AudioValues> ().DamageSound;
		GameOverSound = ValuesGod.GetComponent<AudioValues> ().GameOverSound;
		BackgroundMusic = ValuesGod.GetComponent<AudioValues> ().BackgroundMusic;
		SelectSound = ValuesGod.GetComponent<AudioValues> ().SelectSound;
		LevelCompleteSound = ValuesGod.GetComponent<AudioValues> ().LevelCompleteSound;
	}
}