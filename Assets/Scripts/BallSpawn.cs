using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
	public GameObject ball;


	public float offsetTime;
	private int count;
	private float timecount;
	void Start ()
	{
		

	

	}

	void Update()
	{
		timecount += Time.deltaTime;
		if (timecount>50) {
			count += 5;
			print (count);
			timecount = 0f;
		}
	}

	public  void StartBalls()
	{
		StartCoroutine (BallSpawns ());


	}

//	public void StopBalls()
//	{
//		StopCoroutine (BallSpawns ());
//	}



	private  IEnumerator BallSpawns ( )
	{
		yield return new WaitForSeconds (1f);    
		while (!GameeManager.instance.gameover) {
			
			for (int i = 0; i < 10+count; i++) {
				
				GameObject balls = Instantiate (ball, this.transform.position, Quaternion.identity)as GameObject;

				Transform ballTrans = balls.GetComponent<Transform> ();
				ballTrans.rotation = this.transform.rotation;
				ballTrans.SetParent (this.transform);
				
			}
			yield return  new WaitForSeconds (3f);

		}

	}
}
