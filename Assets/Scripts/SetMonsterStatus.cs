using UnityEngine;
using System.Collections;

public class SetMonsterStatus : MonoBehaviour {

	//モンスターの種類
	public enum MonsterType{
		Warrior, Witch, Dragon
	}
	public MonsterType Type;

	//ステータス
	public float HP, MP, Power;


	//入力値の制限
	private void OnValidate()
	{
		HP    = Mathf.Max (1, HP);
		MP    = Mathf.Max (0, MP);
		Power = Mathf.Max (1, Power);

		if(Type == MonsterType.Warrior){
			MP = 0;
		}
		else if(Type == MonsterType.Witch){
			MP  = Mathf.Max (1, MP);
			HP  = Mathf.Max (MP, HP);
		}
		else if(Type == MonsterType.Dragon){
			HP    = Mathf.Max (100, HP);
			Power = 9999;
		}
	}

	private void Awake(){

		//起動時に各タイプのスクリプトをアタッチ
		if(Type == MonsterType.Warrior){
			gameObject.AddComponent<Warrior> ();
		}
		else if(Type == MonsterType.Witch){
			gameObject.AddComponent<Witch> ();
		}
		else if(Type == MonsterType.Dragon){
			gameObject.AddComponent<Dragon> ();
		}

		//設定された各能力値をスクリプトに設定
		gameObject.GetComponent<Monster> ().HP    = HP;
		gameObject.GetComponent<Monster> ().MP    = MP;
		gameObject.GetComponent<Monster> ().Power = Power;

		//確認
		Debug.Log (gameObject.GetComponent<Monster> ().ToString () + 
			" HP : "    + gameObject.GetComponent<Monster> ().HP +
			" MP : "    + gameObject.GetComponent<Monster> ().MP +
			" Power : " + gameObject.GetComponent<Monster> ().Power
		);

	}

}
