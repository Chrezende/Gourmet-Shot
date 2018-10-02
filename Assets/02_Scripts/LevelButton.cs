using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public	int			level;
	public	Button		buttonLevel;
	private SoundController sc;

	void Awake ()
	{
		sc = FindObjectOfType<SoundController> ();
		buttonLevel = gameObject.GetComponent<Button>();
		buttonLevel.onClick.AddListener(LevelOnClick);

		GameObject config = GameObject.Find("GameConfig");
		if (config.GetComponent<Configurations>().levels[level - 1].unlocked == false)
		{
			gameObject.GetComponent<Button>().enabled = false;
			gameObject.GetComponent<Image>().color = new Color32(158, 158, 158, 255);
			gameObject.transform.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 100);
		}
	}

	void LevelOnClick ()
	{
		GameObject config = GameObject.Find("GameConfig");
		config.GetComponent<SceneManeger>().LoadLevel(config.GetComponent<Configurations>().levels[level - 1].buildIndex);
		sc.Play("menu_button");
	}
}
