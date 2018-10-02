using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	private	Slider			slider;
	private	SoundController	soundManager;

	void Start ()
	{
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundController>();
		slider = GetComponent<Slider>();

		slider.value = soundManager.GetVolume("music");
	}
	
	public void VolumeChange ()
	{
		soundManager.OnVolumeChange(slider);
	}
}
