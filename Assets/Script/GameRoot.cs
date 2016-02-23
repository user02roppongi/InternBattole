using UnityEngine;
using System.Collections;

public class GameRoot : MonoBehaviour {
	public ParamList paramList;

	// Use this for initialization
	void Awake () {
		paramList = new ParamList ();
		TestA ();
	}
	
	void TestA(){
		Debug.Log ("paramList.playerList [0].Name:"+paramList.playerList [0].Name);
		//paramList.playerList [0].Name;
	}

}
