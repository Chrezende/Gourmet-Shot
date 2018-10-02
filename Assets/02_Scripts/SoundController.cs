using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Esse Behaviour controla todas as execuções de audio do jogo, desde musicas de fundo até effects.
using UnityEngine.Events;


public class SoundController : MonoBehaviour {

	public 	Sound[]		sounds; //Array no qual são pre-setados todos os sons do jogo.
	private Sound		backgroundMusic;
    static SoundController instance = null;

	void Awake ()
	{
		
        if (instance != null) {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Faz o GO se manter ativo ao transitar entre scenas.
        }

		foreach(Sound s in sounds) //Cria uma fonte de audio para cada som.
		{
			s.sourse = gameObject.AddComponent<AudioSource>();
			s.sourse.clip = s.clip;

			s.sourse.loop = s.loop;
			s.sourse.volume = s.volume; // *VOLUME
			s.sourse.pitch = s.pitch;
		}

		SceneManager.sceneLoaded += OnLevelLoaded;
	}

	void Start ()
	{
		Play("music");
	}

	void OnLevelLoaded (Scene scene, LoadSceneMode mode) //Carrega uma musica de fundo dependendo do index da scene.
	{/*
		if (sounds [scene.buildIndex].isMusic == true) 
		{
			backgroundMusic = sounds [scene.buildIndex];
			backgroundMusic.loop = true;
			backgroundMusic.sourse.Play ();
		}*/
	}

	public void Play (string name)
	{
		foreach (Sound s in sounds) 
		{
			if (s.name == name) 
			{
				s.sourse.Play();
			}
		}
	}

	public void Pause (string name)
	{
		foreach (Sound s in sounds) 
		{
			if (s.name == name) 
			{
				s.sourse.Pause();
			}
		}
	}

	public void Stop (string name)
	{
		foreach (Sound s in sounds) 
		{
			if (s.name == name) 
			{
				s.sourse.Stop();
			}
		}
	}

	public void OnVolumeChange(Slider slider)
	{
		foreach (Sound s in sounds) 
		{
			s.volume = slider.value;
			s.sourse.volume = slider.value;
		}
	}

	public float GetVolume (string name)
	{
		float sv = 0.5f;
		foreach (Sound s in sounds) 
		{
			if (s.name == name) 
			{
				sv = s.volume;
			}
		}
		return sv;
	}

	public void SetMusicMute ()
	{
		foreach (Sound s in sounds) 
		{
			if (s.isMusic == true) 
			{
				s.sourse.mute = !s.sourse.mute;
			}
		}
	} 

	public void SetSFXMute ()
	{
		foreach (Sound s in sounds) 
		{
			if (s.isSFX == true) 
			{
				s.sourse.mute = !s.sourse.mute;
			} 
		}
	} 

}