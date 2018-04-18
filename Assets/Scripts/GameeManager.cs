using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 控制分数，开始，重新开始等等
/// </summary>
public class GameeManager : MonoBehaviour
{
	//public GameObject[] target;

	public static GameeManager instance;
	private GameObject startui;
	private Text	scoreText;
	private Text hightText;
	private Text currentTimeText;
	public  GameObject player;
	private float time;
	public bool gameover = true;
	private float hightTime;
	private float currentTime;


	public BallSpawn[] ballSpawns;




	void Awake	()
	{
		instance = this;

	}

	void Start ()
	{
//		for (int i = 0; i < target.Length; i++) {
//			DontDestroyOnLoad (target[i]);
//		}




		startui = GameObject.Find ("Start"); 
		scoreText	= GameObject.Find ("score").GetComponent<Text> ();
		hightText = GameObject.Find ("HigthTime").GetComponent<Text> ();
		currentTimeText = GameObject.Find ("oneTime").GetComponent<Text> ();
		scoreText.text = (int)time / 360 + ":" + (int)time / 60 + ":" + (int)time + "";
		startui.SetActive (true);
		hightTime = PlayerPrefs.GetFloat ("高分", 0);
		currentTime = PlayerPrefs.GetFloat ("当前", 0);
		ShowcurrentTime ();
		ShowHigthtime ();





	}


	void Update ()
	{
		if (gameover == false) {
			
			time += Time.deltaTime;
			scoreText.text = "当前：" + (int)time / 60 + ":" + (int)time % 60 + ":" + (int)(time % 1 * 100) / 1 + "";

			PlayerPrefs.SetFloat ("当前", time);
			if (time > hightTime) {
				PlayerPrefs.SetFloat ("高分", time);
			}

		}
	}

	void ShowcurrentTime ()//显示当前成绩
	{
		currentTimeText.text = "当前：" + (int)currentTime / 60 + "分" + (int)currentTime / 1 + "秒" + (int)(currentTime % 1 * 100) / 1 + "";
	}

	void ShowHigthtime ()//显示最高成绩
	{
		hightText.text = "最佳：" + (int)hightTime / 60 + "分" + (int)hightTime / 1 + "秒" + (int)(time % 1 * 100) / 1 + "";
	}

	public void Restart ()
	{
		gameover = true;

		SceneManager.LoadScene ("Main");
	}

	public void StartGame ()
	{


		Instantiate (player, new Vector3 (0f, 0f, 0), Quaternion.identity);
		startui.gameObject.SetActive (false);
		hightText.enabled = false;
		currentTimeText.enabled = false;
		gameover = false;
		for (int i = 0; i < ballSpawns.Length; i++) {
			ballSpawns [i].StartBalls ();
		}
	}

	public void BackGame ()
	{
		SceneManager.LoadScene ("01");
	}

	public void ExitGame ()
	{
		PlayerPrefs.DeleteKey ("当前");
		Application.Quit ();

	}




}
