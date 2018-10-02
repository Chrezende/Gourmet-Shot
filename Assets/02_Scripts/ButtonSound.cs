using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

	private SoundController sc;
	public	Button		buttonSound;

	void Start ()
	{
		sc = FindObjectOfType<SoundController> ();
		buttonSound = gameObject.GetComponent<Button>();
		buttonSound.onClick.AddListener(SoundOnClick);
	}

	public void SoundOnClick ()
	{
		sc.Play("menu_button");
	}
}
