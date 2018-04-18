using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public GameObject[] target;
	public RawImage log;
	private Color temp;
	private AsyncOperation op;
	void Start()
	{
		for (int i = 0; i < target.Length; i++) {
			
			DontDestroyOnLoad (target[i]);
		}
		op = SceneManager.LoadSceneAsync ("01");
		op.allowSceneActivation = false;
		temp = log.color;
	}

	public void GameStart()
	{
	}

	void Update()
	{
//		print (log.color.a);
		temp.a = Mathf.Lerp (temp.a, 2f, Time.deltaTime*0.2f);
		log.color= temp;
		if (temp.a>1.2f) {
			
//			SceneManager.LoadScene ("01");
			op.allowSceneActivation=true;
		}
	}
}
