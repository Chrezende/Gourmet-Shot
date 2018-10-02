using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    private SceneManeger sc;

    private void Awake()
    {
        sc = FindObjectOfType<SceneManeger>();
    }

    void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
            sc.PauseResume();
		}
        //if (Input.GetKeyDown(KeyCode.H)) {
        //    sc.FastFoward();
        //}
    }
}
