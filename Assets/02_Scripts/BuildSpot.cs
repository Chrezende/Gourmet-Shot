using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildSpot : MonoBehaviour {

	private CannonsManager 	cannonsManager;
	private	LevelConfig		levelConfig;
	private SoundController	sc;

	public int 				spotNumber = 0;
	public ClassCannon[] 	cannonLibrary;
	
	// Use this for initialization
	void Start () {
		cannonsManager = FindObjectOfType<CannonsManager>();
		levelConfig = GameObject.Find("LevelConfig").GetComponent<LevelConfig>();
		sc = FindObjectOfType<SoundController> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown(spotNumber.ToString()))
		{
			if (GetComponentInChildren<CannonController>())
			{
				cannonsManager.SetCannonActive(GetComponentInChildren<CannonController>());
			}
			else
			{
				RadialMenuSpawner.ins.SpawnMenu(GetComponent<Interactable>());
			}
		}

		if (Input.GetKeyUp(spotNumber.ToString()))
		{
			RadialMenu menu = FindObjectOfType<RadialMenu>();
			if (menu)
			{
				if (menu.selected)
				{
					Debug.Log(menu.selected.title + " was selected!");
					menu.selected.buttonAction.Invoke();
				}
				Destroy(menu.gameObject);
			}
		}
	}

	public void SpawnCannon (string name)
	{
		foreach (var cannon in cannonLibrary)
		{
			if (cannon.cannonName == name && levelConfig.gold >= cannon.buildGold)
			{
				GameObject can = Instantiate(cannon.cannonGameObj, transform.position, Quaternion.identity) as GameObject;
				can.name = cannon.cannonName;
				can.GetComponent<CannonController>().rangeIncrease = cannon.cannonRangeIncrease;
				can.GetComponent<CannonController>().maxRangeIncrease = cannon.cannonMaxRangeIncrease;
				can.GetComponent<CannonController>().fireRateIncrease = cannon.cannonFireRateIncrease;
				can.GetComponent<CannonController>().maxFireRateIncrease = cannon.cannonMaxFireRateIncrease;
				can.GetComponent<CannonController>().totalGoldSpent = cannon.buildGold;

				can.GetComponent<FireCommand>().fireRate = cannon.cannonFireRate;
				can.GetComponent<FireCommand>().range = cannon.cannonRange;
				can.GetComponent<FireCommand>().projectileType = cannon.projectileType;
				can.GetComponent<FireCommand>().projectileSpeed = cannon.projectileSpeed;

				can.transform.parent = this.transform;
				cannonsManager.GetCannons();
				GetComponent<Interactable>().isInteractable = false;

				levelConfig.gold -= cannon.buildGold;
				sc.Play("builded");
			}
		}
		
	}
}
