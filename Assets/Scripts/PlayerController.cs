using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
	

	private Animator anim;
	
	private Vector3 playerPosition;
	private Vector3 rawPosition;
	private  float maxWith, maxHeight;

	private  Vector3 prePosition;
	private Vector3 lastMousePosition = Vector3.zero;
	private bool isMouseDown = false;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		//把屏幕宽高转成游戏宽高，进行限制；
		Vector3 screenPos = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 screenLimit = Camera.main.ScreenToWorldPoint (screenPos);
		//飞机的宽度和高度
		Vector3 playerwith = GetComponent<SpriteRenderer> ().bounds.extents;
		//获得飞机初始位置
		playerPosition = this.transform.position;
		//计算飞机的移动宽度和高度
		maxWith = screenLimit.x - playerwith.x;
		maxHeight = screenLimit.y - playerwith.y;
//		StartCoroutine (OnMouseDown ());
	}


	void Update ()
	{
		
////		if (Input.touchCount>0&&Input.GetTouch (0).phase==TouchPhase.Moved) {
//			
//		//将鼠标位置转换成游戏世界位置
//		rawPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			
//		//设置飞机将要移动的位置，飞机移动范围控制
//			
//		playerPosition = new Vector3 (rawPosition.x, rawPosition.y, 0);	
//		playerPosition = Vector3.Lerp (playerPosition, rawPosition, Time.deltaTime);
//		playerPosition.z = 0;
//		playerPosition.x = Mathf.Clamp (playerPosition.x, -maxWith, maxWith);
//		playerPosition.y = Mathf.Clamp (playerPosition.y, -maxHeight, maxHeight);
//		//飞机移动
////			GetComponent <Rigidbody2D>().MovePosition (playerPosition);
//		this.transform.position = playerPosition;
			
//		}
//		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//			OnMouseDown ();
//			OnMouseDrag ();
//		}
		if (!GameeManager.instance.gameover) {
			PlayerMove ();
		}

	}

	void PlayerMove()//飞机移动代码
	{
		if (Input.GetMouseButtonDown (0)) {  
			isMouseDown = true;  
		}  
		if (Input.GetMouseButtonUp (0)) {  
			isMouseDown = false;  
			lastMousePosition = Vector3.zero;  
		}  
		if (isMouseDown) {  
			if (lastMousePosition != Vector3.zero) {  
				Vector3 offset = Camera.main.ScreenToWorldPoint (Input.mousePosition) - lastMousePosition; 
				playerPosition += offset;
				playerPosition.x = Mathf.Clamp (playerPosition.x, -maxWith, maxWith);
				playerPosition.y = Mathf.Clamp (playerPosition.y, -maxHeight, maxHeight);
				this.transform.position = playerPosition;  
			}  
			lastMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);  

		}  
	}

	//	IEnumerator OnMouseDown()
	//	{
	//		//将物体由世界坐标系转换为屏幕坐标系
	//		Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
	//		//完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系
	//		//    //             2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是距离
	//		//将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
	//		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	//		while (Input.GetMouseButton(0))
	//		{
	//			//得到现在鼠标的2维坐标系位置
	//			Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
	//			//将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
	//			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
	//			//curPosition就是物体应该的移动向量赋给transform的position属性
	//			transform.position = curPosition;
	//			yield return new WaitForFixedUpdate(); //这个很重要，循环执行
	//		}
	//	}
	//	public void OnMouseDown ()
	//	{
	//
	//		Vector3 mouse = Input.mousePosition;
	//		mouse.z = 0f;
	//		prePosition = Camera.main.ScreenToWorldPoint (mouse);
	//
	//		print ("我点击了");
	//	}
	//
	//
	//	public void OnMouseDrag ()
	//	{
	//		Vector3 mouse = Input.mousePosition;
	//		mouse.z = 0f;
	//		Vector3 currentPosition = Camera.main.ScreenToWorldPoint (mouse);
	//
	//		Vector3 offset = currentPosition - prePosition;
	//		playerPosition += offset;
	//		playerPosition.x = Mathf.Clamp (playerPosition.x, -maxWith, maxWith);
	//		playerPosition.y = Mathf.Clamp (playerPosition.y, -maxHeight, maxHeight);
	//		this.transform.position = playerPosition;
	//		prePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	//
	//	}

	private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Ball")) {
			print ("hah");

			GameeManager.instance.gameover = true;
			anim.SetTrigger ("Die");
			GoogleGM.googlegm.GADInterstitalShow ();
			GameeManager.instance.Restart ();



		}
//		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}




}
