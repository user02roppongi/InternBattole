using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectButton : MonoBehaviour 
{

	// 別スクリプトCombatStartにアクセスするための変数
	private CombatStart combatStart;
	// Use this for initialization
	void Start ()
	{
		combatStart = GameObject.Find ("Canvas").GetComponent<CombatStart> ();

		// ボタンのオンクリックイベント設定
		gameObject.GetComponent<Button> ().onClick.AddListener(KyousyuuSetButton);
	}

	// ボタンクリック時に発動するメソッド,強襲する、しないを決定

	public void KyousyuuSetButton()
	{

		// ボタンの名前がKyousyuuYesならcombatStartにあるKyousyuuSetメソッドにtrueを
		if (gameObject.name == "KyousyuuYes") 
		{
			
			combatStart.KyousyuuSet(true);

		// ボタンの名前がKyousyuuNoならcombatStartにあるKyousyuuSetメソッドにfalseを
		}else if(gameObject.name == "KyousyuuNo")
		{
			
			combatStart.KyousyuuSet(false);
			
		}

		if (gameObject.name == "JinkeiYes") {
			GameObject.Find ("DataBase").GetComponent<LongDistance> ().testStart ();
			Destroy (GameObject.Find ("Canvas/JinkeiSelect"));
		}

		if (gameObject.name == "JinkeiNo") {
			Destroy (GameObject.Find ("Canvas/JinkeiSelect"));
		}
	}
}
