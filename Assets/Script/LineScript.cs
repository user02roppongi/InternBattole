using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GameObject.Find ("Line").AddComponent<TrailRenderer> ();

		Vector3[] path = new Vector3[5];
		path[0] = new Vector3(5f,0,0);
		path[1] = new Vector3(6f,10f,0);
		path[2] = new Vector3(8f,-20f,0);
		path[3] = new Vector3(9f,10f,0);
		path[4] = new Vector3(10f,0,0);

		iTween.MoveTo (gameObject,iTween.Hash("path",path));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
