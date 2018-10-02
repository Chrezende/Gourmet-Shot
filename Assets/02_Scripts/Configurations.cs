using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configurations : MonoBehaviour {

	public 	Level[] levels;
	public	int		actualLevel;

	static Configurations instance = null;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject); //Faz o GO se manter ativo ao transitar entre scenas.
		}
	}
}
