using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int projectileDamage = 1;
	public float projectileCost = 0.1f;
	public float projectileRange = 1.5f;

	void Start ()
	{
		Invoke("Hit",projectileRange);
	}

	public int GetDamage ()
	{
		return projectileDamage;
	} 

	public float GetCost ()
	{
		return projectileCost;
	}

	public void Hit ()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.layer == 30) 
		{
			Destroy (gameObject);
		}
	}
}


