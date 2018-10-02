using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

//Add this to your Button Prefab
public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public 	Image 		circle; 		//button image
	public 	Image 		icon;           //icon in button
	public	Text		costText;
	public 	string 		title;			//identifier (for testing purposes)
	public 	RadialMenu 	myMenu;			//links back to radial menu
	public 	float 		speed = 8f;    //animation speed
	public 	int 		actionCost;
	public 	UnityEvent 	buttonAction;

	Color defaultColor;			//used to track color of icon

	public void Anim()
	{
		StartCoroutine(AnimateButtonIn());
	}

	//make button grow on screen
	IEnumerator AnimateButtonIn(){
		transform.localScale = Vector3.zero;
		float timer = 0f;
		while (timer < (1 / speed)){
			timer += Time.deltaTime;
			transform.localScale = Vector3.one * timer * speed;
			yield return null;
		}
		transform.localScale = Vector3.one;
	}

	//highlights button and sets it to selected
	public void OnPointerEnter (PointerEventData eventData)
	{
		myMenu.selected = this;
		defaultColor = circle.color;
		if (actionCost <= FindObjectOfType<LevelConfig>().gold)
		{
			circle.color = Color.white;
		}
	}

	//de-highlights and de-selects button
	public void OnPointerExit (PointerEventData eventData)
	{
		myMenu.selected = null;
		circle.color = defaultColor;
	}


}
