using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsCanvasRotation : MonoBehaviour {

    private Quaternion Rotation;

	// Update is called once per frame
	void Update () {
        Rotation = transform.parent.transform.rotation;
        transform.rotation = Quaternion.Inverse(Rotation)*Rotation;
	}
}
