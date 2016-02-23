using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatStart : MonoBehaviour 
{

	// データベースの参照
	private ParamList paramlist;

	// プレイヤーのラックの合計値
	private int playerLuck;

	//敵のラックの合計値
	private int enemyLuck;

	// 気配察知の判定　true,false
	private bool kehai;

	// 強襲の判定　true,false
	private bool kyousyuu;

	// Use this for initialization
	void Start ()
	{

		StartCoroutine (CombatS ());
	}



	/*運の判定をするメソッド
	　　 プレイヤーの運が高ければtrueを返す
		エネミーの運が高ければfalseを返す
			値が同じならプレイヤーの判定勝利でtrueを返す*/

	void KehaiJudgi(int playerLuck,int enemiyLuck)
	{
		if (playerLuck > enemiyLuck)
		{
			Debug.Log ("プレイヤーのラックが高いです。");
			this.kehai = true;
		} 

		else if (enemiyLuck > playerLuck)
		{
			Debug.Log ("エネミーのラックが高いです。");
			this.kehai = false;
		} 

		else 
		{

			Debug.Log ("ラックが同じです。");
			this.kehai = true;
		}
	}

	// エネミーの気配察知アニメメソッド
	void EnemiyKehaiAnim()
	{
		Debug.Log ("Enemiyの気配察知のアニメーション発動");


	}

	// プレイヤーの気配察知アニメメソッド
	void PlayerKehaiAnim()
	{
		Debug.Log ("Playerの気配察知のアニメーション発動");
		GameObject textimg = Instantiate (Resources.Load ("Image/TextImage"),new Vector3(0,-130,0),transform.rotation)as GameObject;
		GameObject.Find(textimg.name+"/Text").GetComponent<Text>().text = "正義！！";
		GameObject img =	Resources.Load ("Image/Player")as GameObject;
		GameObject image = Instantiate (Resources.Load ("Image"),new Vector3(350f,0,0),transform.rotation)as GameObject;
		image.GetComponent<Image> ().sprite = img.GetComponent<SpriteRenderer> ().sprite;
		textimg.transform.SetParent (image.transform,false);
		image.transform.SetParent (GameObject.Find ("Canvas").transform, false);
		image.AddComponent<ImageScript> ();
		image.GetComponent<ImageScript> ().Corou (3f, 2, -380f);
	}


	//　強襲アニメーションのメソッド
	void PlayerKyousyuuAnim()
	{
		Debug.Log ("Playerの強襲アニメーション発動");
		/*for (int i = 0; i < 3; i++) {
			GameObject imgP =	Resources.Load ("Image/Player")as GameObject;
			GameObject imgE = Resources.Load ("Image/EnemiyUI")as GameObject;
			GameObject imageP = Instantiate (Resources.Load ("Image"), new Vector3 (350f, -200+200*i, 0), transform.rotation)as GameObject;
			GameObject imageE = Instantiate (Resources.Load ("Image"), new Vector3 (-350f,-200+200*i, 0), transform.rotation)as GameObject;
			imageP.GetComponent<Image> ().sprite = imgP.GetComponent<SpriteRenderer> ().sprite;
			imageP.transform.SetParent (GameObject.Find ("Canvas").transform, false);
			imageP.AddComponent<ImageScript> ();
			imageP.GetComponent<ImageScript> ().Corou (3f, 2, -380f);

			imageE.GetComponent<Image> ().sprite = imgE.GetComponent<SpriteRenderer> ().sprite;
			imageE.transform.SetParent (GameObject.Find ("Canvas").transform, false);
			imageE.AddComponent<ImageScript> ();
			imageE.GetComponent<ImageScript> ().Corou (3f, 2, 380f);
		}*/

		GameObject imgP =	Resources.Load ("Image/Player")as GameObject;
		GameObject imgE = Resources.Load ("Image/EnemiyUI")as GameObject;
		GameObject imageP = Instantiate (Resources.Load ("Image"), new Vector3 (350f, 100, 0), transform.rotation)as GameObject;
		GameObject imageE = Instantiate (Resources.Load ("Image"), new Vector3 (-350f,100, 0), transform.rotation)as GameObject;

		GameObject textimgP = Instantiate (Resources.Load ("Image/TextImage"),new Vector3(0,-130,0),transform.rotation)as GameObject;
		GameObject.Find(textimgP.name+"/Text").GetComponent<Text>().text = "オラオラー";

		GameObject textimgE = Instantiate (Resources.Load ("Image/TextImage"),new Vector3(0,-130,0),transform.rotation)as GameObject;
		GameObject.Find(textimgE.name+"/Text").GetComponent<Text>().text = "どけどけー";

		textimgP.transform.SetParent (imageP.transform,false);
		textimgE.transform.SetParent (imageE.transform,false);

		imageP.GetComponent<Image> ().sprite = imgP.GetComponent<SpriteRenderer> ().sprite;
		imageP.transform.SetParent (GameObject.Find ("Canvas").transform, false);
		imageP.AddComponent<ImageScript> ();
		imageP.GetComponent<ImageScript> ().Corou (3f, 2, -380f);

		imageE.GetComponent<Image> ().sprite = imgE.GetComponent<SpriteRenderer> ().sprite;
		imageE.transform.SetParent (GameObject.Find ("Canvas").transform, false);
		imageE.AddComponent<ImageScript> ();
		imageE.GetComponent<ImageScript> ().Corou (3f, 2, 380f);
	}


	// Yesボタン
	//GameObject yes;

	// NOボタン
	//GameObject no;

	// 強襲をするかしないかを選択するボタンを作成
	void PlayerKyousyuuSelect()
	{
		// 強襲選択ボタンを格納する変数
		GameObject kyousyuuButton;


		Debug.Log ("選択ボタンをインスタンス");

		//　Instantiateするときの座標を格納する変数
		Vector3 xyz = new Vector3 (transform.position.x, transform.position.y, transform.position.z);


		/* ResourcesにあるKyousyuuSelectオブジェクトを変数xyzに格納した座標にInstantiate
		 * と同時にゲームオブジェクト型にキャストして変数KyousyuuButtonに格納
		*/
		kyousyuuButton = Instantiate (Resources.Load ("UI/KyousyuuSelect"), xyz, transform.rotation)as GameObject;

		// kyousyuuButtonをCanvasの子要素に設定
		kyousyuuButton.transform.SetParent (GameObject.Find ("Canvas").transform);

		// kyousyuuButtonの名前をKyousyuuSelectに変更,(Clone)を消す。
		kyousyuuButton.name = "KyousyuuSelect";


		/* KyousyuuButtonの子要素にあるKyousyuuYesという名前のイエスボタン,
		 * KyousyuuNoという名前のノーボタンに別スクリプトのセレクトボタンをADDコンポーネント
		 * */
		GameObject.Find("Canvas/KyousyuuSelect/KyousyuuYes").AddComponent<SelectButton> ();
		GameObject.Find("Canvas/KyousyuuSelect/KyousyuuNo").AddComponent<SelectButton> ();
	}


	// 強襲するかしないかをtrueかfalseで受け取り実行
	public void KyousyuuSet(bool select)
	{
		
		kyousyuu = select;

		// 選択ボタンの削除
		Destroy(GameObject.Find("Canvas/KyousyuuSelect"));


		// 強襲する場合はtrueで陣形選択へ
		if (kyousyuu == true)
		{
			Debug.Log("強襲はtrueです");

			JinkeiScript jinkei = GameObject.Find("DataBase").GetComponent<JinkeiScript> ();
			jinkei.JinkeiStart ();
		}

		// しない場合は索的メソッドにtrueを送る
		if (kyousyuu == false)
		{
			Debug.Log("強襲はfalse");
			bool a = true;
			Debug.Log (a);
			SakutekiScript sakuteki = GameObject.Find("DataBase").GetComponent<SakutekiScript> ();
			sakuteki.KehaiStart (a);
		}
	}


	IEnumerator CombatS(){
		paramlist = GameObject.Find("DataBase").GetComponent<ParamList> ();


		// 各プレイヤーのラックをplayerLuckに加算

		for (int i = 0; i < paramlist.playerList.Count; i++)
		{
			playerLuck += paramlist.playerList [i].Luck;
		}

		//　各敵キャラのラックをenemyLuckに加算

		for (int i = 0; i < paramlist.enemyList.Count; i++) 
		{
			enemyLuck += paramlist.enemyList [i].Luck;
		}


		// 気配察知の判定にtrueかfalseを代入するメソッド

		KehaiJudgi (playerLuck, enemyLuck);

		/*
			trueならプレイヤー気配察知アニメーション発動メソッドへ
			falseならエネミー気配察知アニメーション発動メソッドへ

		 */

		if (kehai == true)
		{
			yield return new WaitForSeconds (1f);
			PlayerKehaiAnim();

			yield return new WaitForSeconds (5f);

			//強襲アニメメソッドへ
			PlayerKyousyuuAnim ();

			yield return new WaitForSeconds (5f);
			//　強襲選択メソッドへ
			PlayerKyousyuuSelect ();
		}

		else if(kehai == false)
		{	
			yield return new WaitForSeconds (3f);
			EnemiyKehaiAnim();

			yield return new WaitForSeconds (3f);

			// 索的への条件分岐！！索的のスクリプトkehaiStartメソッドへfalseを送る

			SakutekiScript sakuteki = GetComponent<SakutekiScript> ();
			sakuteki.KehaiStart (false);
		}
	}
}
