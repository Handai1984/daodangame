using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerMg : MonoBehaviour
{
	private  GoogleAD banner1;
	private  GoogleAD banner2;

	void Start ()
	{
		banner1 = GameObject.Find ("GoogleADOne").GetComponent<GoogleAD> ();
		banner2 = GameObject.Find ("GoogleADTwo").GetComponent<GoogleAD> ();
		banner1.RequestBanner ();
		banner1.BannerHide ();
		banner2.RequestBanner ();
		banner2.BannerHide ();

		StartCoroutine (ShowBanners ());

	}



	IEnumerator ShowBanners ()
	{
		yield return new WaitForSeconds (1f);

		while (true) {
			banner1.BannerShow ();
			print ("我是第一个横幅展示");
			yield return new WaitForSeconds (10f);
			banner1.BannerHide ();
			print ("我是第一个横幅隐藏");

			banner2.BannerShow ();
			print ("我是第二个横幅展示");
			yield return new WaitForSeconds (10f);
			banner2.BannerHide ();
			print ("我是第二个横幅隐藏");

		}
	}


}
