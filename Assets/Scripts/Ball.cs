using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float speed;
	private Vector3 dic;
	Quaternion a;
	public Transform player;
	void Start ()
	{
		
		speed = Random.Range (1f, 3f);
	dic = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f,1f), 0);

		a = Quaternion.FromToRotation (transform.position, dic);

	}


	void Update ()
	{

		this.transform.rotation = a;
		this.transform.Translate (Vector3.up* speed * Time.deltaTime);
	}

//	private void OnCollisionExit2D(Collision2D collision)
//	{
//		if (collision.gameObject.CompareTag ("Bounds")) {
//			Destroy (this.gameObject);
//		}
//	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Bounds")) {
			Destroy (this.gameObject);
		}
	}
}
