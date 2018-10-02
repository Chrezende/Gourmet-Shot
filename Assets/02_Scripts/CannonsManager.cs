using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ClassCannon
{
	/// <summary>
	/// Nome do canhão.
	/// </summary>
	public string cannonName;

	/// <summary>
	/// GameObject do canhão.
	/// </summary>
	public GameObject cannonGameObj;

	/// <summary>
	/// GameObject do canhão.
	/// </summary>
	public int buildGold;

	/// <summary>
	/// Range do tiro.
	/// </summary>
	public float cannonRange;

	/// <summary>
	/// Incremento de range por upgrade.
	/// </summary>
	public float cannonRangeIncrease;

	/// <summary>
	/// Maxima quantidade de upgrades de range.
	/// </summary>
	public int cannonMaxRangeIncrease;

	/// <summary>
	/// Fire rate do canhão.
	/// </summary>
	public float cannonFireRate;

	/// <summary>
	/// Incremento de fire rate por upgrade.
	/// </summary>
	public float cannonFireRateIncrease;

	/// <summary>
	/// Maxima quantidade de upgrades de fire rate.
	/// </summary>
	public int cannonMaxFireRateIncrease;

	/// <summary>
	/// Tipo de projétil.
	/// </summary>
	public GameObject projectileType;

	/// <summary>
	/// GameObject do canhão.
	/// </summary>
	public float projectileSpeed;
	
}

public class CannonsManager : MonoBehaviour {

	List<BuildSpot> spots;
	List<CannonController> cannons;

	// Use this for initialization
	public void GetCannons () {
		cannons = GetComponentsInChildren<CannonController>().ToList<CannonController>();
		Debug.Log("Canhoes em jogo: " + cannons.Count);
	}
	
	public void SetCannonActive(CannonController activeCannon)
	{
		foreach (var cannon in cannons)
		{
			if (cannon == activeCannon)
			{
				if (cannon.cannonActive)
				{
					cannon.cannonActive = false;
					cannon.GetComponent<FireCommand>().CancelFire();
				}
				else
				{
					cannon.cannonActive = true;
					cannon.GetComponent<FireCommand>().StartFire();
				}
			}else {
				cannon.cannonActive = false;
				cannon.GetComponent<FireCommand>().CancelFire();
			}
			
		}
	}
}
