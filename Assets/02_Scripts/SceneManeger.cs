using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour 
{
	public bool gamePaused = false;

	public void LoadLevel (int buildindex) //Chamada de nova Scene.
	{
		SceneManager.LoadScene(buildindex);
		GetComponent<Configurations>().actualLevel = buildindex;
	}

	public void LoadLevel (string levelName) //Chamada de nova Scene usando o nome dela
	{
		SceneManager.LoadScene(levelName);
	}

	public void QuitRequest () //Encerramento do jogo.
	{
		Application.Quit();
	}

	public void StartMenu () //Chamada da Tela de Vitória
	{
		LoadLevel(0);
	}

	public void Options () //Chamada da Tela de Vitória
	{
		LoadLevel(1);
	}

	public void WinScreen () //Chamada da Tela de Vitória
	{
		LoadLevel(2);
	}

	public void LoseScreen () //Chamada da Tela de Vitória
	{
		LoadLevel(3);
	}

	public void LevelSelect () //Chamada da Tela de Vitória
	{
		LoadLevel(4);
	}
	
	public void PauseResume()	//Pausa ou Despausa o jogo
	{
		if (Time.timeScale == 1) {
			Debug.Log ("Jogo Pausado");
			Time.timeScale = 0;
		} else {
			Debug.Log ("Jogo Despausado");
			Time.timeScale = 1;
		}
	}
	
	public void FastFoward()	//Acelera o tempo
	{
		if (Time.timeScale == 1) {
			Debug.Log ("2x");
			Time.timeScale = 2;
		} else {
			Debug.Log ("1x");
			Time.timeScale = 1;
		}
	}
}
