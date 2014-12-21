using UnityEngine;
using System.Collections;

public class MonsterMaker : MonoBehaviour {

	//モンスターデータがあるディレクトリのパス
	public const string MONSTER_DATA_PATH = "Data/";

	void Awake () {
	
		//ステージ番号を設定(する処理が入るが、今は特にないので1)
		int stageNo = 1;

		//モンスターデータを取得する
		MonsterData monsterData = Resources.Load<MonsterData> (MONSTER_DATA_PATH + stageNo);

		if(monsterData == null){
			Debug.Log ("モンスターデータが生成されていません");
			return;
		}
		if(monsterData.list.Count == 0){
			Debug.Log ("モンスターデータに登録されているモンスターが0です");
			return;
		}

		//登録されているデータの数だけモンスターを生成、各データを設定
		foreach(MonsterData.Param param in monsterData.list){

			GameObject monster = new GameObject ();

			monster.name = param.GameObjectName;

			monster.transform.position = param.Position;
			monster.transform.rotation = param.Rotation;

			monster.AddComponent<SetMonsterStatus> ();

			monster.GetComponent<SetMonsterStatus> ().Type  = param.Type;
			monster.GetComponent<SetMonsterStatus> ().HP    = param.HP;
			monster.GetComponent<SetMonsterStatus> ().MP    = param.MP;
			monster.GetComponent<SetMonsterStatus> ().Power = param.Power;

		}

	}

}
