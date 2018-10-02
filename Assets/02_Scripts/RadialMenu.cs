using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Add this to your menu prefab
public class RadialMenu : MonoBehaviour 
{

	public Text 		label;			//object name appears here
	public RadialButton buttonPrefab;	//button to instantiate
	public RadialButton selected;       //button that is selected (leave this empty)

	public void SpawnButtons (Interactable obj) 
	{
		StartCoroutine(AnimateButtons (obj));
	}

	IEnumerator AnimateButtons (Interactable obj) 
	{
		for (int i = 0; i < obj.options.Length; i++){
			RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
			newButton.transform.SetParent(transform, false);
			float theta = (2 * Mathf.PI / obj.options.Length) * i;
			float xPos = Mathf.Sin(theta);
			float yPos = Mathf.Cos(theta);
			newButton.transform.localPosition = new Vector3 (xPos, yPos, 0f) * 50f;
			newButton.actionCost = obj.options[i].actionCost;
			newButton.costText.text = obj.options[i].actionCost.ToString();
			if (obj.options[i].actionCost > FindObjectOfType<LevelConfig>().gold)
			{
				newButton.circle.color = new Color(0.20f, 0.20f, 0.20f);
				newButton.costText.color = new Color(0.9f, 0.2f, 0.2f);
			}
			else
			{
				newButton.circle.color = new Color(1f,1f,1f);
				newButton.costText.color = new Color(0.2f, 0.2f, 0.2f);
			}
			newButton.circle.sprite = obj.options[i].buttonSprite;
			newButton.icon.sprite = obj.options[i].iconSprite;
			newButton.title = obj.options[i].title;
			newButton.buttonAction = obj.options[i].action;
			newButton.myMenu = this;
			newButton.Anim();
			yield return new WaitForSeconds(0.12f);
		}
	}

	//if mouse is released over a button, activate that button
	void Update(){
		if (Input.GetMouseButtonUp(0))
		 {
			if (selected){
				Debug.Log (selected.title + " was selected!");
				selected.buttonAction.Invoke();
			}
			Destroy(gameObject);
		}
	}

}
