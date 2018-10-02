using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {


	[HideInInspector]
	public 	Image 	saladBar;
	public	bool	eatSalad = true;
	public 	int 	FomeSalad = 3;
	private	int		actualFomeSalad = 0;

	[HideInInspector]
	public 	Image 	sauceBar;
	public	bool	eatSauce = false;
	public 	int 	FomeSauce = 0;
	private	int		actualFomeSauce = 0;

	[HideInInspector]
	public 	Image 	porkBar;
	public	bool	eatPork = false;
	public 	int 	FomePork = 0;
	private	int		actualFomePork = 0;

	public 	int 	gold;
	public 	int 	bonusGold;

	public	int 	points = 10;

	public	bool	satisfeito = false;
	public	bool	muitoSatisfeito = false;

	void Start ()
	{
		if (FomeSalad == 0)
		{
			Destroy(saladBar.gameObject, 0.01f);
			Destroy(saladBar.transform.parent.gameObject);
		}
		if (FomeSauce == 0)
		{
			Destroy(sauceBar.gameObject,0.01f);
			Destroy(sauceBar.transform.parent.gameObject);
		}
		if (FomePork == 0)
		{
			Destroy(porkBar.gameObject,0.01f);
			Destroy(porkBar.transform.parent.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == 30) {
			Destroy (gameObject);
		}
		if (col.gameObject.layer == 11) {
			Projectile projectile = col.gameObject.GetComponent<Projectile> ();
			switch (projectile.tag) {
			case "Salad":
				actualFomeSalad = actualFomeSalad + projectile.GetDamage ();
				if (actualFomeSalad < 0) {
					actualFomeSalad = 0;
				}
				if (saladBar) {
					saladBar.fillAmount = ((float)actualFomeSalad / (float)FomeSalad);
				}
				break;

			case "Sauce":
				actualFomeSauce = actualFomeSauce + projectile.GetDamage ();
				if (actualFomeSauce < 0) {
					actualFomeSauce = 0;
				}
				if (sauceBar) {
					sauceBar.fillAmount = ((float)actualFomeSauce / (float)FomeSauce);
				}
				break;

			case "Pork":
				actualFomePork = actualFomePork + projectile.GetDamage ();
				if (actualFomePork < 0) {
					actualFomePork = 0;
				}
				if (porkBar) {
					porkBar.fillAmount = ((float)actualFomePork / (float)FomePork);
				}
				break;

			default:
				break;
			}
			projectile.GetComponent<Projectile> ().Hit ();
		}

		if (eatSalad && eatSauce && eatPork) {
			if (actualFomeSalad >= FomeSalad && eatSalad) {
				satisfeito = true;
			}
			if (actualFomeSauce >= FomeSauce && eatSauce) {
				satisfeito = true;
			}
			if (actualFomePork >= FomePork && eatPork) {
				satisfeito = true;
			}
			if (actualFomeSalad >= FomeSalad && actualFomeSauce >= FomeSauce && actualFomePork >= FomePork) {
				muitoSatisfeito = true;
			}
		}
		if (eatSalad && eatSauce) {
			if (actualFomeSalad >= FomeSalad && eatSalad) {
				satisfeito = true;
			}
			if (actualFomeSauce >= FomeSauce && eatSauce) {
				satisfeito = true;
			}
			if (actualFomeSalad >= FomeSalad && actualFomeSauce >= FomeSauce)
				muitoSatisfeito = true;
		}
		if (eatSalad && eatPork) {
			if (actualFomeSalad >= FomeSalad && eatSalad) {
				satisfeito = true;
			}
			if (actualFomePork >= FomePork && eatPork) {
				satisfeito = true;
			}
			if (actualFomeSalad >= FomeSalad && actualFomePork >= FomePork)
				muitoSatisfeito = true;
		}
		if (eatPork && eatSauce) {
			if (actualFomeSauce >= FomeSauce && eatSauce) {
				satisfeito = true;
			}
			if (actualFomePork >= FomePork && eatPork) {
				satisfeito = true;
			}
			if (actualFomeSauce >= FomeSauce && actualFomePork >= FomePork)
				muitoSatisfeito = true;
		}
		if (actualFomeSalad >= FomeSalad && eatSalad && !eatSauce && !eatPork) {
			satisfeito = true;
		}
		if (actualFomeSauce >= FomeSauce && eatSauce && !eatSalad && !eatPork) {
			satisfeito = true;
		}
		if (actualFomePork >= FomePork && eatPork && !eatSalad && !eatSauce) {
			satisfeito = true;
		}
	}

}
