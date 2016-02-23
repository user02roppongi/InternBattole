using UnityEngine;
using System.Collections;

public class JinkeiScript : MonoBehaviour {

	ParamList paramlist;
	bool detailTeki=true;
	bool stateDown;
	bool decide1 = true;
	bool decide2 = true;
	bool decide3 = true;

	string formation = "長蛇の陣"; 

	// Use this for initialization
	public	void JinkeiStart () {
		paramlist = gameObject.GetComponent<ParamList> ();


		//detailTeki = sakuteki.getDetail ();
		if (detailTeki == true) {
			//敵のパラメータや陣形を表示

			Debug.Log ("敵の陣形 : "+ this.formation);
				for (int i = 0; i < paramlist.enemyList.Count; i++) {
					Debug.Log (paramlist.enemyList [i].Name);
					Debug.Log (paramlist.enemyList [i].Hp);
					Debug.Log (paramlist.enemyList [i].Speed);
				//アニメーション×３

				//キャラのはめ込み


				}
			if (decide1 == true) {
				Debug.Log ("自軍陣形選択へ移行しますか?");
				if(decide2 == true){
					Debug.Log ("味方の陣形　:　長蛇の陣が選択されました。");
			
					if(decide3 == true){
						Debug.Log ("この内容で戦闘を行いますか？　Yes/No");
						GameObject JinkeiSelect =	Instantiate (Resources.Load ("UI/JinkeiSelect"),
							new Vector3 (GameObject.Find("Canvas").transform.position.x, GameObject.Find("Canvas").transform.position.y,GameObject.Find("Canvas").transform.position.z),
							transform.rotation)as GameObject;

						JinkeiSelect.name = "JinkeiSelect";
						JinkeiSelect.transform.SetParent (GameObject.Find("Canvas").transform);

						GameObject.Find ("Canvas/JinkeiSelect/JinkeiYes").AddComponent<SelectButton> ();
						GameObject.Find ("Canvas/JinkeiSelect/JinkeiNo").AddComponent<SelectButton> ();
					}
				}						
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
				
	}
}
