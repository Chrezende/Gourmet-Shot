using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	void Awake ()
	{
		GameObject config = GameObject.Find("GameConfig");
		gameObject.GetComponentInChildren<Text>().text = config.GetComponent<Configurations>().levels[config.GetComponent<Configurations>().actualLevel].points.ToString();
	}

}
