using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Result : MonoBehaviour {
	private ParamList paramList;



	//バトル画面の勝利判定
	private bool BattoleJugie;
	// Use this for initialization
	void Start () 
	{
		// データベースにあるPramListを参照
		paramList = GameObject.Find("DataBase").GetComponent<ParamList> ();


	}

	// リサルト開始の処理
	public void ResultStart ()
	{
		Debug.Log ("先頭結果リザルトを開始します");
		Result2 ();
	}


	// リサルト２の処理（大破、小破の判定）
	void Result2()
	{
		Debug.Log ("損害確認処理");
		Debug.Log ("各自軍ユニット、敵軍ユニットの残HPより大破、小破等の損害状況を各個決定");


		for (int i = 0; i < paramList.playerList.Count; i++)
		{
			if (paramList.playerList [i].Hp == 0) 
			{
				Debug.Log (paramList.playerList [i].Name + "は大破しました");
			} 
			else if (paramList.playerList [i].Hp >= (paramList.playerList [i].MaxHp / 2)) 
			{
				Debug.Log (paramList.playerList [i].Name +  "は大破も小破もしてません");
			} 
			else
			{
				Debug.Log (paramList.playerList [i].Name + "は小破しました");
			}
		}

		for (int i = 0; i < paramList.enemyList.Count; i++) 
		{

			if (paramList.enemyList [i].Hp == 0)
			{
				Debug.Log (paramList.enemyList [i].Name + "は大破しました");
			} 

			else if (paramList.enemyList [i].Hp >= (paramList.enemyList [i].MaxHp / 2))
			{
				Debug.Log (paramList.enemyList [i].Name +  "は大破も小破もしてません");
			}

			else
			{
				Debug.Log (paramList.enemyList [i].Name + "は小破しました");
			}
		}
		Result3 ();
	}

	// 戦闘結果のアニメーションを表示させるメソッド
	void Result3()
	{
		Debug.Log ("先頭結果のアニメーションを表示します");

		Result4 ();
	}

	//勝敗の判定を行うメソッド
	void Result4()
	{
		Debug.Log ("勝敗判定処理を行います。");
		ResultRank ();


		Result5 ();
	}

	// 敵キャラの残り総HP
	int enemysHp;

	// 味方の残り総HP
	int playersHp;

	// 敵キャラの総HP最大値
	int enemysHpMax;

	// 味方の総HP最大値
	int playersHpMax;

	// 味方の生存人数
	int playerNoBreak;

	// 敵の生存人数
	int enemyNoBreak;

	// ランクの文字
	string rank;

	// 勝敗を決定する前の処理メソッド
	void ResultRank(){
		
		Debug.Log ("Player.Enemyの現在HPの合計値を計算");

		// 味方の生存人数と残り総HPの計算
		for (int i = 0; i < paramList.playerList.Count; i++)
		{
			playersHp = paramList.playerList [i].Hp;
			playersHpMax = paramList.playerList [i].MaxHp;
			if (paramList.playerList [i].Hp > 0)
			{
				playerNoBreak++;
			}
		}

		// 敵の生存人数と残り総HPの計算
		for (int i = 0; i < paramList.enemyList.Count; i++) 
		{
			enemysHp = paramList.enemyList [i].Hp;
			enemysHpMax = paramList.enemyList [i].MaxHp;
			if(paramList.enemyList[i].Hp>0)
			{
				enemyNoBreak++;
			}
		}


		returnRank ();
		Debug.Log ("Playerのｈｐ総量は"+playersHp+"敵のHP総量は"+enemysHp);
		Debug.Log ("Playerのｈｐ最大値は"+playersHpMax+"敵のHP最大値は"+enemysHpMax);
	}

	// ランク判定メソッド 1
	void returnRank(){
		// 味方のゲージ
		float playerGage;

		// 敵のゲージ
		float enemyGage;

		// 味方ゲージの計算
		playerGage = ((float)playersHp / playersHpMax);

		// 敵ゲージの計算
		enemyGage = ((float)enemysHp / enemysHpMax);

		// 敵が全滅ならS true
		if (enemyNoBreak == 0)
		{
			BattoleJugie = true;
			rank = "S";
		}

		// 敵を半分以上撃破ならA true
		else if (enemyNoBreak < ((float)paramList.enemyList.Count / 2))
		{
			BattoleJugie = true;
			rank = "A";
		} 

		// 味方ゲージが敵のゲージの2.5倍以上 B true
		else if (playerGage >= (enemyGage * 2.5f))
		{
			BattoleJugie = true;
			rank = "B";
		} 

		// 味方ゲージが敵のゲージ以上　C false
		else if (playerGage >= enemyGage)
		{
			BattoleJugie = false;
			rank = "C";
		} 

		// 味方ゲージが敵のゲージの半分以上 D false
		else if (playerGage >= enemyGage / 2) {
			BattoleJugie = false;
			rank = "D";
		} 

		// 味方ゲージが敵のゲージの半分未満　E	false
		else {
			BattoleJugie = false;
			rank = "E";
		}
	}


	// ランク判定メソッド 2
	void returnRank2(int playerhp,int enemyshp)
	{

		// 敵１体以上倒したかどうかで勝敗判定（true or false）
		if(enemyNoBreak < paramList.enemyList.Count){

			// 敵が全滅　S true
			if (enemysHp == 0)
			{
				BattoleJugie = true;
				rank = "S";
			}

			// 敵を半分以上撃破　A true
			else if (enemyNoBreak < ((float)paramList.enemyList.Count / 2))
			{
				BattoleJugie = true;
				rank = "A";
			}

			// 1体以上撃破　B false
			else
			{
				BattoleJugie = true;
				rank = "B";
			}

		}

		// 敵を１体も倒してない
		else{
			//　味方の生存人数が半分以下　E false
			if (playerNoBreak < ((float)paramList.playerList.Count / 2))
			{
				BattoleJugie = false;
				rank = "E";
			} 

			// 味方が一人でもHPが０　D　false
			else if (playerNoBreak < paramList.playerList.Count)
			{
				BattoleJugie = false;
				rank = "D";
			}


			//　敵を１体も倒せれてない　C false
			else
			{
				BattoleJugie = false;
				rank = "C";
			}
		}
	}
		

	// 勝敗結果を表示
	void Result5()
	{
		Debug.Log ("勝敗は"+BattoleJugie+rank+"ランクです。");

		Result6 ();
	}


	// MVP決定、レベルアップ
	void Result6()
	{
		// 総EXPでレベル更新
		paramList.ExpDate ();
		Debug.Log ("MVPを決定します。");

		// MVPのIDを格納
		int id = returnMVP ();

		Debug.Log ("今回のMVPは"+paramList.playerList[id].Name);
		Debug.Log ("敵に与えたダメージ" + paramList.playerList[id].EnemyDamage + "です");
		Debug.Log ("現在のLVは" + paramList.playerList [id].Level);
		Debug.Log ("MVPの現在EXPは" + paramList.playerList [id].Exp);
		Debug.Log ("MVPの獲得したEXPは" + paramList.playerList [id].BattoleExp);

		//  MVPのバトルで得た経験地を総EXPに加算
		paramList.playerList [id].Exp += paramList.playerList [id].BattoleExp;

		//  MVPのバトルで得た経験地をリセット
		paramList.playerList [id].BattoleExp = 0;

		// レベルデータの更新
		paramList.ExpDate ();
		Debug.Log ("集計後のEXPは"+paramList.playerList [id].Exp);
		Debug.Log ("集計後のLVは" + paramList.playerList [id].Level);

		Debug.Log ("MVP以外のキャラのEXPを集計します");


		// MVP以外のレベルアップ処理
		for (int i = 0; i < paramList.playerList.Count; i++)
		{
			if (i != id) 
			{
				Debug.Log ("NAME:"+paramList.playerList[i].Name);
				Debug.Log ("敵に与えたダメージ" + paramList.playerList[i].EnemyDamage + "です");
				Debug.Log ("現在のLVは" + paramList.playerList [i].Level);
				Debug.Log ("現在EXPは" + paramList.playerList [i].Exp);
				Debug.Log ("獲得したEXPは" + paramList.playerList [i].BattoleExp);
				paramList.playerList [i].Exp += paramList.playerList [i].BattoleExp;
				paramList.playerList [i].BattoleExp = 0;
				paramList.ExpDate ();
				Debug.Log ("集計後のEXPは"+paramList.playerList [i].Exp);
				Debug.Log ("集計後のLVは" + paramList.playerList [i].Level);
			}
		}

		Debug.Log ("戦闘結果終了");
	}

	// MVPを決めてMVPのIDを返却するメソッド
	int returnMVP()
	{
		//mvpのidを格納
		int mvpId = 0;
		Debug.Log ("敵に与えたダメージの多い人をMVPにします！");

		// 次のリストの数値と比較して多かったらIDにその数値を入れる
		for (int i = 0; i < paramList.playerList.Count-1; i++)
		{
			if (paramList.playerList[i].EnemyDamage < paramList.playerList[i+1].EnemyDamage)
			{
				mvpId = i + 1;
			}
		}


		return mvpId;

	}

	void Result7(){
	}

	void Result8(){
	}


}
