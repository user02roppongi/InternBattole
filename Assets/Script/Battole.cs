using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Battole : MonoBehaviour {
	private int playerLuck;
	private int enemiyLuck;

	private bool kehai;
	private bool kyousyuu;

	// Use this for initialization
	void Start ()
	{
		// プレイヤーの運の合計値
		playerLuck = 5; 

		//　敵キャラの運の合計値
		enemiyLuck = 1; 

		// 運の判定で気配にtrueかfalseを代入

		KehaiJudgi (playerLuck, enemiyLuck);

		/*
			trueならプレイヤー気配察知アニメーション発動メソッドへ
			falseならエネミー気配察知アニメーション発動メソッドへ

		 */

		if (kehai == true)
		{
			PlayerKehaiAnim();
		}

		else if(kehai == false)
		{
			EnemiyKehaiAnim();
		}
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

		else {

			Debug.Log ("ラックが同じです。");
			this.kehai = true;
		}
	}

	// エネミーの気配察知アニメメソッド
	 void EnemiyKehaiAnim()
	{
		Debug.Log ("Enemiyの気配察知のアニメーション発動");
		SakutekiScript sakuteki = GetComponent<SakutekiScript> ();

		sakuteki.KehaiStart (false);
	}

	// プレイヤーの気配察知アニメメソッド
	void PlayerKehaiAnim()
	{	
		Debug.Log ("Playerの気配察知のアニメーション発動");

		//強襲選択アニメメソッドへ
		PlayerKyousyuuAnim ();
	}

	void PlayerKyousyuuAnim()
	{
		Debug.Log ("Playerの強襲アニメーション発動");

		PlayerKyousyuuSelect ();
		}

	GameObject yes;
	GameObject no;
	GameObject kyousyuuButton;
	void PlayerKyousyuuSelect()
	{

		Debug.Log ("選択ボタンをインスタンス");


		Vector3 xyz = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		kyousyuuButton = Instantiate (Resources.Load ("UI/KyousyuuSelect"), xyz, transform.rotation)as GameObject;


		kyousyuuButton.transform.SetParent (GameObject.Find ("Canvas").transform);


		kyousyuuButton.name = "KyousyuuSelect";

		GameObject.Find("Canvas/KyousyuuSelect/KyousyuuYes").AddComponent<SelectButton> ();
		GameObject.Find("Canvas/KyousyuuSelect/KyousyuuNo").AddComponent<SelectButton> ();
	}

	public void KyousyuuSet(bool select)
	{
		kyousyuu = select;
		Destroy(GameObject.Find("Canvas/KyousyuuSelect"));

		if (kyousyuu == true)
		{
			Debug.Log("強襲はtrueです");
		}

		if (kyousyuu == false)
		{
			Debug.Log("強襲はfalse");
			bool a = true;
			Debug.Log (a);
			SakutekiScript sakuteki = GetComponent<SakutekiScript> ();
			sakuteki.KehaiStart (a);
		}
	}

}
