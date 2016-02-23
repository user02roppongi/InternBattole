using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;

public class MiddleDistance : MonoBehaviour {
	CloseCombat closeCombat;
	//GameRoot gameRoot;
	ParamList paramList;

	//中距離戦B参加リスト
	ArrayList bList = new ArrayList();

	//スカイリスト
	List<Equipment> mySkyList = new List<Equipment>();
	List<Equipment> enemySkyList = new List<Equipment>();
	//スパイリスト
	List<Equipment> mySpiList = new List<Equipment>();
	List<Equipment> enemySpiList = new List<Equipment>();

	// Use this for initialization
	void Start () {
		closeCombat = this.gameObject.GetComponent <CloseCombat>();
		//gameRoot = GameObject.Find ("GameRoot").GetComponent<GameRoot>();
		paramList = GameObject.Find("DataBase").GetComponent<ParamList>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testStart(){
		MiddleDistanceA ();
	}

	//中距離戦A
	public void MiddleDistanceA(){
		Debug.Log ("中距離戦Aスタート！");
		//スカイホーク持ち確認
		if (SkyCheck ()) {
			//プレイヤーの攻撃
			MyArmyAttack ();
			//敵の攻撃
			EnemyAmyAttack ();
		}
		//リーダー大破チェック
		LeaderMajorDamageCheck ();
		//中距離戦Bへ
		MiddleDistanceB ();
	}

	//スカイホーク持ち確認
	bool SkyCheck(){
		Debug.Log ("スカイホーク持ち確認");
		bool skyFlag = false;
		//自軍
		foreach (PlayerParam playerParam in paramList.playerList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがスカイだったら
				if(equipment.Type == EquipmentType.Sky){
					Debug.Log ("味方スカイいる！");
					mySkyList.Add (equipment);
					skyFlag = true;
				}

			}
		}
		//敵運
		foreach (PlayerParam playerParam in paramList.enemyList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがスカイだったら
				if(equipment.Type == EquipmentType.Drone){
					Debug.Log ("敵スカイいる！");
					enemySkyList.Add (equipment);
					skyFlag = true;
				}

			}
		}
		return skyFlag;

	}

	//プレイヤーの攻撃
	void MyArmyAttack(){
		Debug.Log ("プレイヤーの攻撃");
		//Debug.Log ("プレイヤードローンの攻撃");
		if(mySkyList.Count != 0){
			//myDroneList[0]
			foreach (Equipment equipment in mySkyList) {
				//Equipment equipment = myDroneList[0];
				Debug.Log ("ターゲット選択");
				int num = Random.Range (0, paramList.enemyList.Count);
				PlayerParam playerParam = paramList.enemyList [num];
				Debug.Log ("プレイヤースカイの攻撃");
				Debug.Log (playerParam.Name + "に" + equipment.Power + "のダメージ！");
				playerParam.Hp -= equipment.Power;
				if (playerParam.Hp <= 0) {
					playerParam.Hp = 0;
					Debug.Log (playerParam.Name + "は死亡した。");
				}
			}
		}
		Debug.Log ("プレイヤースカイの攻撃終了");
	}
	//敵の攻撃
	void EnemyAmyAttack(){
		Debug.Log ("敵の攻撃");
		if(enemySkyList.Count != 0){
			//myDroneList[0]
			foreach (Equipment equipment in enemySkyList) {
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




	//------------------------------------------
	//中距離戦B
	void MiddleDistanceB(){
		Debug.Log ("中距離戦Aスタート！");
		//中距離ステータス持ち存在チェック
		if(MiddleStatusCheck()){
			//弾切れチェック
			OutOfAmmoCheck ();
			//ターゲット選択
			//TargetSelect();
			//攻撃処理
			AttackB();

		}

		//中距離戦Cへ
		MiddleDistanceC ();
	}

	//中距離ステータス持ち存在チェック
	bool MiddleStatusCheck(){
		bool statusFlag = false;
		//自軍
		foreach (PlayerParam playerParam in paramList.playerList) {
			if(playerParam.MiddlePower > 0){
				bList.Add (playerParam);
				statusFlag = true;
			}
		}
		//敵運
		foreach (PlayerParam playerParam in paramList.enemyList) {
			if(playerParam.MiddlePower > 0){
				bList.Add (playerParam);
				statusFlag = true;
			}
		}

		//☆ソートはややっこしいので後回し

		//bList.Add ();
		//射程順にソート
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
		Debug.Log ("中距離戦B攻撃");
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
					enemy.Hp -= playerParam.MiddlePower;
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
					enemy.Hp -= playerParam.MiddlePower;
					if (enemy.Hp <= 0) {
						enemy.Hp = 0;
						Debug.Log (enemy.Name + "は死亡した。");
					}
				}
			}
		}
	}


	//------------------------------------------
	//中距離戦C
	void MiddleDistanceC(){
		Debug.Log ("中距離戦Bスタート！");
		//スパイダー持ち確認
		if (SpiderCheck ()) {
			//プレイヤーの攻撃
			MyArmyAttackC ();
			//敵の攻撃
			EnemyAmyAttackC ();
		}

		//リーダー大破チェック
		if (LeaderMajorDamageCheck ()) {
			//リザルトへ
		} else {
			//中距離戦終了
			EndCombat();
		}
	}

	//スパイダー持ち確認
	bool SpiderCheck(){
		Debug.Log ("スパイ存在チェック");
		bool spiderFlag = false;
		//自軍
		foreach (PlayerParam playerParam in paramList.playerList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがスパイだったら
				if(equipment.Type == EquipmentType.Drone){
					Debug.Log ("スパイいる！");
					mySpiList.Add (equipment);
					spiderFlag = true;
				}

			}
		}
		//敵運
		foreach (PlayerParam playerParam in paramList.enemyList) {
			foreach (Equipment equipment in playerParam.EquipmentList) {
				//装備タイプがドローンだったら
				if(equipment.Type == EquipmentType.Drone){
					Debug.Log ("敵スパイいる！");
					enemySpiList.Add (equipment);
					spiderFlag = true;
				}

			}
		}
		return spiderFlag;
	}

	//プレイヤーの攻撃
	void MyArmyAttackC(){
		Debug.Log ("プレイヤーの攻撃C");
	}
	//敵の攻撃
	void EnemyAmyAttackC(){
		Debug.Log ("敵の攻撃C");
	}

	//リーダー大破チェック
	bool LeaderMajorDamageCheck(){
		//リーダー大破ならリザルト画面へ
		Debug.Log ("リーダー大破チェック");
		return false;
	}

	//中距離戦終了
	void EndCombat(){
		//白兵戦 移行するか確認
		Debug.Log ("中距離戦終了");
		Debug.Log ("白兵戦をしますか？");
		closeCombat.CloseCombatA ();
	}
}
