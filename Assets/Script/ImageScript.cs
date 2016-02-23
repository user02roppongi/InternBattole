using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour {

	// Use this for initialization
	public void Corou(float time,int roop,float length){
		StartCoroutine (ImageS (time,roop,length));
	}
		
		


	IEnumerator ImageS(float time,int roop,float length){
		for (int i = 0; i < roop; i++) {

			iTween.MoveTo (gameObject, new Vector3 (transform.position.x +length, transform.position.y, transform.position.z), 5f);
			yield return new WaitForSeconds (time);
		}
		Destroy (gameObject);
	}
}
