using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleGM : MonoBehaviour
{

	public static GoogleGM googlegm;

	//谷歌广告
	private GoogleAD google1;
	private GoogleAD google2;
	private List<GoogleAD> gad;
	private int countInter;
	//计数器

	/// <summary>
	///是时候展示真正的实力啦
	/// </summary>


	private void Awake ()
	{
		googlegm = this;

	}

	private void Start ()
	{
		
		gad = new List<GoogleAD> ();

		//查找广告脚本
		google1 = GameObject.Find ("GoogleADOne").GetComponent<GoogleAD> ();
		google2 = GameObject.Find ("GoogleADTwo").GetComponent<GoogleAD> ();

		gad.Add (google1);
		gad.Add (google2);
		print ("我装了几个进去？" + gad.Count);
		//初始化广告脚本
		GADInitInterstitial ();
		GADInitBanner ();
		GADBannerShow ();
	}






	//初始化插屏和横幅广告
	void GADInitInterstitial ()
	{
		for (int i = 0; i < gad.Count; i++) {
			gad [i].RequestInterstitial ();

		}
	}
	//初始化横幅广告
	void GADInitBanner ()
	{
		for (int i = 0; i < gad.Count; i++) {

			gad [i].RequestBanner ();
			gad [i].BannerHide ();
		}
	}


	//轮流显示插屏
	public void GADInterstitalShow ()
	{
		if (countInter >= gad.Count) {
			GADInitInterstitial ();
			countInter = 0;

		} else {

			gad [countInter].ShowInterstitial ();
			print ("显示插屏" + countInter);
			countInter++;

		}
	}

	/// <summary>
	/// 轮流播放横幅
	/// </summary>
	public void GADBannerShow ()
	{
		//轮流播放
		StartCoroutine (TurnBannerShow ());
	}

	IEnumerator TurnBannerShow ()
	{
		for (int i = 0; i < gad.Count; i++) {

			yield return new WaitForSeconds (1f);
			gad [i].BannerShow ();
			print ("显示横幅" + i);
			yield return new WaitForSeconds (10f);
			gad [i].BannerHide ();
			print ("隐藏横幅" + i);
			if (i == gad.Count - 1) {
				i = -1;
			}

		}
	}
}
