using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotNumber : MonoBehaviour {

	void Awake ()
	{
		GetComponent<Text>().text = gameObject.transform.parent.parent.GetComponentInParent<BuildSpot>().spotNumber.ToString();
	}
}
