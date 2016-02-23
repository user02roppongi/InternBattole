using UnityEngine;
using System.Collections;


public class SakutekiScript : MonoBehaviour {

	ParamList paramlist;
	/*int sakutekiMikata = 6;
	int sakutekiTeki =6;
	int [] searchenemyMikata =new int[sakutekiMikata];		//　味方の索敵パラメータを取得して、
	int [] searchenemyTeki =new int[sakutekiTeki];*/
	int maxSakutekiMikata;// = sakutekiMikata.Max();					//　最大値を求める
	int maxSakutekiTeki;// = sakutekiTeki.Max();									
	int criterion=5;


	bool detailTeki =false;							//　敵パラメータの開示(デフォルトではfalse)
	bool stateDown = false;  //　回避率低下(デフォルトではfalse)

	public bool getDetail(){
		return detailTeki;
	}
	public bool getStateDown(){
		return stateDown;
	}

	public void Mikatakara(){
		
		if(this.maxSakutekiTeki >= this.criterion){
			detailTeki = true;		//　判定値より最大値が大きい場合、開示フラグを立てる
			//　+索敵成功アニメーション(味方);
			if(this.maxSakutekiMikata >= this.criterion){
				stateDown =true;
				//　+索敵成功アニメーション(敵);
			}


		}
		GameObject.Find ("DataBase").GetComponent<JinkeiScript> ().JinkeiStart ();
	}

	public void Tekikara(){
		// 変数ステータス


		if(this.maxSakutekiTeki >= this.criterion){
			this.stateDown =true;
			//　索敵成功アニメーション(敵);

			if(this.maxSakutekiMikata >= this.criterion){
				this.detailTeki = true;		//　判定値より最大値が大きい場合、開示フラグを立てる
				//　索敵成功アニメーション(味方);
			}
		}
		GameObject.Find ("DataBase").GetComponent<JinkeiScript> ().JinkeiStart ();
	}






	// Use this for initialization
	void Start () {
		paramlist = GetComponent <ParamList> ();

		maxSakutekiMikata = paramlist.playerList [0].SearchEnemy;
		for (int i = 0; i < (paramlist.playerList.Count-1); i++) {
			if (paramlist.playerList [i].SearchEnemy < paramlist.playerList [i + 1].SearchEnemy) {
				maxSakutekiMikata = paramlist.playerList [i+1].SearchEnemy;
			}
		}

		maxSakutekiTeki = paramlist.enemyList [0].SearchEnemy;
		for (int i = 0; i < (paramlist.enemyList.Count-1); i++) {
			if (paramlist.enemyList [i].SearchEnemy < paramlist.enemyList [i + 1].SearchEnemy) {
				maxSakutekiMikata = paramlist.enemyList [i+1].SearchEnemy;
			}
		}
			
	}


	public void KehaiStart(bool MyKehaisacchi){
		Debug.Log ("気配察知は"+MyKehaisacchi);

		if (MyKehaisacchi == true) {
			Debug.Log ("味方の索的");
			Mikatakara ();

		} else {
			Debug.Log ("敵の索的");
			Tekikara ();
		}
	}
	// Update is called once per frame
	void Update () {
		
			
	}
}
