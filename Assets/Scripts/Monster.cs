using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

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

		if(Type == MonsterType.Dragon){
			HP    = Mathf.Max (100, HP);
			Power = Mathf.Max (10, Power);
		}
	}

}
