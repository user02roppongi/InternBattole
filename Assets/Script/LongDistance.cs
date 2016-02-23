using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;

//コミットテスト２

public class LongDistance : MonoBehaviour {
	MiddleDistance middleDistance;
	//GameRoot gameRoot;
	ParamList paramList;

	bool kehaiFlag = true;

	//遠距離戦B参加リスト
	ArrayList bList = new ArrayList();

	//ドローンリスト
	List<Equipment> myDroneList = new List<Equipment>();
	List<Equipment> enemyDroneList = new List<Equipment>();

	void Start () {
		middleDistance = this.gameObject.GetComponent <MiddleDistance>();
		//gameRoot = GameObject.Find ("GameRoot").GetComponent<GameRoot>();
		paramList =	GameObject.Find("DataBase").GetComponent<ParamList>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testStart(){
		LongDistanceA ();
	}

	//遠距離戦A
	void LongDistanceA(){
		Debug.Log ("遠距離戦Aスタート！");
		//ドローンいるか
		if (DroneCheck()) {
			if (kehaiFlag) {
				//プレイヤーの攻撃
				MyArmyAttack ();
				//敵の攻撃
				EnemyAmyAttack ();
			} else {
				//敵の攻撃
				EnemyAmyAttack ();
				//プレイヤーの攻撃
				MyArmyAttack ();
			}
		}
		//リーダー大破チェック
		//LeaderMajorDamageCheck();
		//リーダ大破でもB行く？
		//遠距離戦Bへ
		LongDistanceB();
	}

	//ドローン存在チェック
	bool DroneCheck(){
		Debug.Log ("ドローン存在チェック");
		bool droneFlag = false;
		//自軍
		foreach (PlayerParam playerParam in paramList.playerList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがドローンだったら
				if(equipment.Type == EquipmentType.Drone){
					Debug.Log ("ドローンいる！");
					myDroneList.Add (equipment);
					droneFlag = true;
				}

			}
		}
		//敵運
		foreach (PlayerParam playerParam in paramList.enemyList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがドローンだったら
				if(equipment.Type == EquipmentType.Drone){
					Debug.Log ("敵ドローンいる！");
					enemyDroneList.Add (equipment);
					droneFlag = true;
				}

			}
		}
		return droneFlag;
	}

	//プレイヤーの攻撃
	void MyArmyAttack(){
		//Debug.Log ("プレイヤードローンの攻撃");
		if(myDroneList.Count != 0){
			//myDroneList[0]
			foreach (Equipment equipment in myDroneList) {
				//Equipment equipment = myDroneList[0];
				Debug.Log ("ターゲット選択");
				int num = Random.Range (0, paramList.enemyList.Count);
				PlayerParam playerParam = paramList.enemyList [num];
				Debug.Log ("プレイヤードローンの攻撃");
				Debug.Log (playerParam.Name + "に" + equipment.Power + "のダメージ！");
				playerParam.Hp -= equipment.Power;
				if (playerParam.Hp <= 0) {
					playerParam.Hp = 0;
					Debug.Log (playerParam.Name + "は死亡した。");
				}
			}
		}
		Debug.Log ("プレイヤードローンの攻撃終了");
	}
	//敵の攻撃
	void EnemyAmyAttack(){
		//Debug.Log ("敵ドローンの攻撃");
		if(enemyDroneList.Count != 0){
			//myDroneList[0]
			foreach (Equipment equipment in enemyDroneList) {
				//Equipment equipment = myDroneList[0];
				Debug.Log ("ターゲット選択");
				int num = Random.Range (0, paramList.enemyList.Count);
				PlayerParam playerParam = paramList.playerList [num];
				Debug.Log ("敵の攻撃");
				Debug.Log (playerParam.Name + "に" + equipment.Power + "のダメージ！");
				playerParam.Hp -= equipment.Power;
				if (playerParam.Hp <= 0) {
					playerParam.Hp = 0;
					Debug.Log (playerParam.Name + "は死亡した。");
				}
			}
		}
		Debug.Log ("敵ドローンの攻撃終了");
	}



	//------------------------------
	//遠距離戦B
	void LongDistanceB(){
		Debug.Log ("遠距離戦Bスタート！");
		//遠距離ステータス持ち存在チェック
		if(LongStatusCheck()){
			//弾切れチェック
			OutOfAmmoCheck ();
			//ターゲット選択
			//TargetSelect();
			//攻撃処理
			AttackB();
		}
		//リーダー大破チェック
		if (LeaderMajorDamageCheck ()) {
			//リザルトへ
		} else {
			//遠距離戦終了
			EndCombat();
		}
	}



	//遠距離ステータス持ち存在チェック
	bool LongStatusCheck(){
		bool statusFlag = false;
		//自軍
		foreach (PlayerParam playerParam in paramList.playerList) {
			if(playerParam.LongPower > 0){
				bList.Add (playerParam);
				statusFlag = true;
			}
		}
		//敵運
		foreach (PlayerParam playerParam in paramList.enemyList) {
			if(playerParam.LongPower > 0){
				bList.Add (playerParam);
			
				statusFlag = true;
			}
		}




		//☆ソートはややっこしいので後回し
		//bList.Sort ((a, b) => a.Speed - b.Speed);

		Debug.Log ("遠距離戦ステータスチェック！");
		Debug.Log ("遠距離戦B参加リスト作成");
		Debug.Log ("射程順にソート");

		return statusFlag;
	}

	//弾切れチェック
	void OutOfAmmoCheck(){
		Debug.Log ("弾切れチェック");
		foreach (PlayerParam playerParam in paramList.playerList) {
			if (playerParam.Bullet == 0) {
				//弾切れ
				Debug.Log ("弾切れです。");
			}
		}
	}

	void TargetSelect(){
		Debug.Log ("ターゲット選択");
	}

	void AttackB(){
		Debug.Log ("遠距離戦B攻撃");
		if(bList.Count != 0){
			foreach (PlayerParam playerParam in bList) {
				if (!playerParam.iseEemy) {
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
				} else {
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
				}
			}
		}
	}


	//リーダー大破チェック
	bool LeaderMajorDamageCheck(){
		//リーダー大破ならリザルト画面へ
		Debug.Log ("リーダー大破チェック");

		return false;
	}
		
	//遠距離戦終了
	void EndCombat(){
		Debug.Log ("遠距離戦終了");
		middleDistance.MiddleDistanceA ();
	}
}
