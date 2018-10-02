using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

	private	SoundController	soundManager;

	void Start ()
	{
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundController>();
	}

	public void MuteMusic ()
	{
		soundManager.SetMusicMute();
	}

	public void MuteSFX ()
	{
		soundManager.SetSFXMute();
	}
}
