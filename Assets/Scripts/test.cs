using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public GameObject[] target;
	void Start () {
		for (int i = 0; i < target.Length; i++) {
			DontDestroyOnLoad (target[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
