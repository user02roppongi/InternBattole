using UnityEngine;
using System.Collections;

public class CloseCombat : MonoBehaviour {
	//GameRoot gameRoot;
	ParamList paramList;
	// Use this for initialization
	void Start () {
		//gameRoot = GameObject.Find ("GameRoot").GetComponent<GameRoot>();
		paramList = GameObject.Find("DataBase").GetComponent<ParamList>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testStart(){
		CloseCombatA ();
	}


	public void CloseCombatA(){
		Debug.Log ("白兵戦スタート！");
		//プレイヤーの攻撃
		MyArmyAttack ();
		//敵の攻撃
		EnemyAmyAttack ();
		//白兵戦終了
		EndCombat();
	}

	//プレイヤーの攻撃
	void MyArmyAttack(){
		Debug.Log ("プレイヤーの攻撃");
		if(paramList.playerList.Count != 0){
			
			foreach (PlayerParam playerParam in paramList.playerList) {
				Debug.Log ("ターゲット選択");
				//☆運ステース補正
				int num = Random.Range (0, paramList.enemyList.Count);
				PlayerParam enemy = paramList.enemyList [num];
				//☆装備によるステータス補正
				//☆回避機能
				Debug.Log (playerParam.Name+"の攻撃");
				Debug.Log (enemy.Name + "に" + playerParam.LongPower + "のダメージ！");
				enemy.Hp -= playerParam.LongPower;
				if (enemy.Hp <= 0) {
					enemy.Hp = 0;
					Debug.Log (enemy.Name + "は死亡した。");
				}
				//☆死亡したらターゲットからはずす
			}

			foreach (PlayerParam playerParam in paramList.enemyList) {
				Debug.Log ("ターゲット選択");
				//☆運ステース補正
				int num = Random.Range (0, paramList.playerList.Count);
				PlayerParam enemy = paramList.playerList [num];
				//☆装備によるステータス補正
				//☆回避機能
				Debug.Log (playerParam.Name+"の攻撃");
				Debug.Log (enemy.Name + "に" + playerParam.LongPower + "のダメージ！");
				enemy.Hp -= playerParam.LongPower;
				if (enemy.Hp <= 0) {
					enemy.Hp = 0;
					Debug.Log (enemy.Name + "は死亡した。");
				}
				//☆死亡したらターゲットからはずす
			}



		}

	}
	//敵の攻撃
	void EnemyAmyAttack(){
		Debug.Log ("敵の攻撃");
	}

	//中距離戦終了
	void EndCombat(){
		Debug.Log ("白兵戦終了");
		Debug.Log ("戦闘結果へ");
		GameObject.Find ("DataBase").GetComponent<Result> ().ResultStart ();
	}

}
