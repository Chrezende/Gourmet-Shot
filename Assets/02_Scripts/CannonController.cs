using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	public bool 		cannonActive = false;

	public float 		rangeIncrease = 0.01f;
	public int 			actualRangeIncrease = 0;
	public int 			maxRangeIncrease = 5;
	public int 			rangeIncreaseCost = 5;

	public float 		fireRateIncrease = 0.01f;
	public int 			actualFireRateIncrease = 0;
	public int			maxFireRateIncrease = 5;
	public int 			fireRateIncreaseCost = 5;

	public int 			totalGoldSpent;

	private	LevelConfig	levelConfig;

	void Start () 
	{
		levelConfig = GameObject.Find("LevelConfig").GetComponent<LevelConfig>();
		actualRangeIncrease = 0;
		actualFireRateIncrease = 0;
		foreach (var option in GetComponent<Interactable>().options)
		{
			if (option.title == "Upgrade Range")
			{
				option.actionCost = fireRateIncreaseCost;
			}

			if (option.title == "Upgrade FireRate")
			{
				option.actionCost = fireRateIncreaseCost;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (cannonActive && (Time.timeScale == 1))
		{
			Vector3 cannonPosition = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 direction = Input.mousePosition - cannonPosition;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
		}
	}

	public void UpgradeRange()
	{
		if (actualRangeIncrease < maxRangeIncrease && levelConfig.gold >= rangeIncreaseCost)
		{
			actualRangeIncrease++;

			totalGoldSpent += rangeIncreaseCost;
			levelConfig.gold -= rangeIncreaseCost;
			rangeIncreaseCost += rangeIncreaseCost*actualRangeIncrease;

			foreach (var option in GetComponent<Interactable>().options)
			{
				if (option.title == "Upgrade Range")
				{
					option.actionCost = rangeIncreaseCost;
				}
			}

			GetComponent<FireCommand>().range += rangeIncrease;
		}
		else
		{
			Debug.Log("But it did nothing!");
		}
	}

	public void UpgradeFireRate()
	{
		if (actualFireRateIncrease < maxFireRateIncrease && levelConfig.gold >= fireRateIncreaseCost)
		{
			actualFireRateIncrease++;

			totalGoldSpent += fireRateIncreaseCost;
			levelConfig.gold -= fireRateIncreaseCost;
			fireRateIncreaseCost += fireRateIncreaseCost*actualFireRateIncrease;
			foreach (var option in GetComponent<Interactable>().options)
			{
				if(option.title == "Upgrade FireRate")
				{
					option.actionCost = fireRateIncreaseCost;
				}
			}
			
			GetComponent<FireCommand>().fireRate += fireRateIncrease;
		}
		else
		{
			Debug.Log("But it did nothing!");
		}

	}

	public void SellCannon()
	{
		levelConfig.gold += totalGoldSpent/2;
		this.transform.parent.GetComponentInParent<Interactable>().isInteractable = true;
		
		Destroy(this.gameObject,0.1f);
	}
}
