using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Umeng;

public class UMController : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		GA.StartWithAppKeyAndReportPolicyAndChannelId ("5abaee4db27b0a487f000095", Analytics.ReportPolicy.BATCH, "App Store");
		GA.Start ();
		GA.StartLevel ("02");
		print ("我开启了友盟统计");
	}
	

}
