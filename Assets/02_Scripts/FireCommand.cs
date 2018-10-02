using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : MonoBehaviour {

	public 	float 			range = 4f;
	public 	float 			fireRate = 1f;
	public 	bool 			isFireEnable = true;
	public 	float 			projectileSpeed = 10f;
	public 	int 			damage = 1;
	public	string			fireSound;
	public 	GameObject 		projectileType;
	private SoundController sc;
	private	BuildSpot		buildSpot;	

	private	Animator	animator;

	void Start ()
	{
		animator = gameObject.GetComponent<Animator> ();
		sc = FindObjectOfType<SoundController> ();
		buildSpot = GetComponentInParent<BuildSpot>();

		foreach (ClassCannon cannon in buildSpot.cannonLibrary) 
		{
			if (cannon.cannonName == gameObject.name) 
			{
				range = cannon.cannonRange;
				fireRate = cannon.cannonFireRate;
			}
		}
	}

	public void StartFire ()
	{
		//CancelInvoke ("Fire");
		//InvokeRepeating ("Fire", fireRate, fireRate);
		animator.speed = fireRate * 1.5f;
		animator.SetBool("isShooting", true);
	}

	public void CancelFire ()
	{
		animator.SetBool("isShooting", false);
	}

	void Fire ()
	{
		if (isFireEnable) 
		{
			foreach (Transform child in transform) 
			{
				GameObject projectile = Instantiate (projectileType, child.transform.position, transform.rotation) as GameObject;
				Rigidbody2D lazerBody = projectile.GetComponent<Rigidbody2D> ();
				projectile.GetComponent<Projectile>().projectileRange = range;
				projectile.GetComponent<Projectile>().projectileDamage = damage;
				lazerBody.velocity = transform.right * projectileSpeed;
				sc.Play(fireSound);
			}
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
