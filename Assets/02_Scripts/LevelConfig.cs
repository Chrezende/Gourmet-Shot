using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelConfig : MonoBehaviour {

	public	int		buildIndex = 5;
	public 	int 	gold = 0;
	public 	int 	satisfeitos = 0;
	public 	int 	insatisfeitos = 0;
	public 	int 	points = 0;
	public	int 	defeatCondition = 5;

	[HideInInspector]
	public 	int 	numUnits;

	void Start ()
	{
		numUnits = GameObject.Find("Spawner").GetComponent<Spawner>().GetTotalUnits();
		buildIndex = GameObject.Find("GameConfig").GetComponent<Configurations>().actualLevel;
		gold = GameObject.Find("GameConfig").GetComponent<Configurations>().levels[buildIndex - 5].startGold;
	}

	void Update ()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		GameObject.Find("Satisfable Text").GetComponent<Text>().text = satisfeitos.ToString();
		GameObject.Find("Insatisfable Text").GetComponent<Text>().text = insatisfeitos.ToString();
		GameObject.Find("Gold Text").GetComponent<Text>().text = "$ " + gold;
	}
}
