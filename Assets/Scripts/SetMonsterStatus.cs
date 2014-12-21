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

	private void Update(){
		//モンスタースクリプトをアタッチしていなければ追加。
		if(!gameObject.GetComponent<Monster>()){
			AttachMonsterScript ();
		}
	}

	//各タイプのスクリプトをアタッチ
	private void AttachMonsterScript(){

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
