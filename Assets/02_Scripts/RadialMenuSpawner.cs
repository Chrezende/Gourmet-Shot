﻿using UnityEngine;
using System.Collections;

//Add this to the Canvas where the menu should appear
public class RadialMenuSpawner : MonoBehaviour {

	public static RadialMenuSpawner ins;
	public RadialMenu menuPrefab;			//prefab menu to instantiate

	//TODO: fix this terrible singleton setup
	void Awake(){
		ins = this;
	}

	//instantiates the menu at the position of the mouse
	public void SpawnMenu(Interactable obj){
		if (obj.isInteractable)
		{
			Vector3 objPosition = Camera.main.WorldToScreenPoint(obj.transform.position);
			

			RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
			newMenu.transform.SetParent (transform, false);
			newMenu.transform.position = objPosition;
			newMenu.label.text = obj.title.ToUpper();
			newMenu.SpawnButtons(obj);
		}
		
	}

}
