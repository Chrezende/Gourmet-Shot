using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour 
{
	public	Wave[]	waves;

	private GameObject waveTextUIgameObject;
	private GameObject waveTimerPanelGameObject;

	void Start ()
	{
		waveTextUIgameObject = GameObject.Find("Wave Text");
		waveTimerPanelGameObject = GameObject.Find("WaveTimer Panel");

		StartCoroutine("SpawnWaves");
		
	}

	public int GetTotalUnits ()
	{
		int u = 0;
		foreach (var wave in waves)
		{
			foreach (var unitType in wave.waveUnits)
			{
				u += unitType.numberOfUnits;
			}
		}
		Debug.Log(u +" units vão ser spawnados!");
		return u;
	}

	IEnumerator SpawnWaves()
	{
		EscreverWave(-1);
		for (int i = 0; i < waves.Length; i++)
		{
			StartCoroutine("WaveCounterStart", i);
			yield return new WaitForSeconds(waves[i].waveGap);

			EscreverWave(i);
			foreach (var unitType in waves[i].waveUnits)
			{
				for (int j = 0; j < unitType.numberOfUnits; j++)
				{
					GameObject unitGameObj = Instantiate(unitType.unitGameObj, transform.position, Quaternion.identity) as GameObject;
					unitGameObj.transform.parent = this.transform;
					yield return new WaitForSeconds(unitType.gapBtwnUnits);
				}
			}
			
			
		}		
	}
	
	private void EscreverWave(int i){
		if (i+1 < 9){
				waveTextUIgameObject.GetComponent<Text>().text = (i+1) + "         " + waves.Length;
			}
			else {
				waveTextUIgameObject.GetComponent<Text>().text = (i+1) + "       " + waves.Length;
			}
	}

	IEnumerator WaveCounterStart(int actualWave)
	{
		waveTimerPanelGameObject.SetActive(true);

		float timer = waves[actualWave].waveGap;
		while (timer > 0)
		{
			if (actualWave == 0)
			{
				waveTimerPanelGameObject.GetComponentInChildren<Text>().text = "Starting in " + timer.ToString();
			}
			else
			{
				waveTimerPanelGameObject.GetComponentInChildren<Text>().text = "Next wave in " + timer.ToString();
			}
			
			yield return new WaitForSeconds(1);
			timer--;
		}

		waveTimerPanelGameObject.gameObject.SetActive(false);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(this.transform.position,1);
	}

}
