using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Canvas configCanvas;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			configCanvas.gameObject.SetActive(true);
		}
		else
		{
			configCanvas.gameObject.SetActive(false);
		}
	}
}
