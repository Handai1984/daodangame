using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour {
	public GameObject[] target;
	private Image musicOn;
	private Image musicOff;

	void Start()
	{
		for (int i = 0; i < target.Length; i++) {
			DontDestroyOnLoad (target[i]);
		}
		musicOn = GameObject.Find ("MusicOn").GetComponent<Image>();
		musicOff = GameObject.Find ("MusicOff").GetComponent<Image>();
	}

	public  void  GameStart()
	{
		//DontDestroyOnLoad (target);
		SceneManager.LoadScene ("Main");
	}


	public  void  MusicOff()
	{
		musicOn.enabled = false;
		musicOff.enabled = true;
	}

	public void MusicOn()
	{
		musicOff.enabled = false;
		musicOn.enabled = true;
	}

}
