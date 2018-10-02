using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deadline : MonoBehaviour {

	private LevelConfig		levelConfig;
	private Life			unit;
	public GameObject		coin;

	void Start ()
	{
		levelConfig = GameObject.Find("LevelConfig").GetComponent<LevelConfig>();
	}

	//void OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == 8) 
		{
			unit = col.gameObject.GetComponent<Life>();

			if (unit.satisfeito == true) 
			{
				levelConfig.gold += unit.gold;
				levelConfig.satisfeitos++;
				levelConfig.points += unit.points;
				GameObject coinObj = Instantiate(coin, this.transform.position, Quaternion.identity);
				coinObj.transform.parent = this.transform;

			}

			if (unit.muitoSatisfeito == true) 
			{
				levelConfig.gold += unit.bonusGold;
				levelConfig.points += unit.points;
				GameObject coinObj = Instantiate(coin, this.transform.position, Quaternion.identity);
				coinObj.transform.parent = this.transform;
			}

			if (unit.satisfeito == false) 
			{
				levelConfig.insatisfeitos++;
				levelConfig.points -= unit.points;
			}
		}
		FinishCheck ();
	}

	void FinishCheck ()
	{
		if (levelConfig.insatisfeitos >= levelConfig.defeatCondition)
		{
			GameObject.Find("GameConfig").GetComponent<SceneManeger>().LoseScreen();
		}

		if((levelConfig.satisfeitos + levelConfig.insatisfeitos) == levelConfig.numUnits && levelConfig.insatisfeitos <= levelConfig.defeatCondition)
		{ 
			GameObject.Find("GameConfig").GetComponent<Configurations>().levels[levelConfig.buildIndex - 4].unlocked = true;
			GameObject.Find("GameConfig").GetComponent<Configurations>().levels[levelConfig.buildIndex - 5].points = levelConfig.points;
			GameObject.Find("GameConfig").GetComponent<SceneManeger>().WinScreen();
		}
	}
}
