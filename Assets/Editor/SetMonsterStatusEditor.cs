using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(SetMonsterStatus))]
public class SetMonsterStatusEditor : Editor
{

	public override void OnInspectorGUI() {
		SetMonsterStatus monster = target as SetMonsterStatus;

		//入力されたモンスターの種類を設定
		monster.Type = (SetMonsterStatus.MonsterType)EditorGUILayout.EnumPopup( "モンスターの種類", monster.Type);

		//共通の注記
		EditorGUILayout.HelpBox("体力とパワーは0に設定できません。", MessageType.Info, true );

		//各タイプ毎に注記を表示
		if(monster.Type == SetMonsterStatus.MonsterType.Warrior){
			EditorGUILayout.HelpBox("Warriorは魔法が使えないのマジックポイントは設定できません", MessageType.Info, true );
		}
		else if(monster.Type == SetMonsterStatus.MonsterType.Witch){
			EditorGUILayout.HelpBox("Witchはマジックポイントを0にできません。\nまた、体力より低いマジックポイントも設定できません。", MessageType.Info, true );
		}
		else if(monster.Type == SetMonsterStatus.MonsterType.Dragon){
			EditorGUILayout.HelpBox("Dragonのパワーは固定なので設定できません", MessageType.Info, true );
		}


		//HPはどのタイプでも設定
		monster.HP = Mathf.Max(1, EditorGUILayout.FloatField ("体力", monster.HP));

		//戦士はMPが0なので設定しない
		if(monster.Type != SetMonsterStatus.MonsterType.Warrior){
			monster.MP = Mathf.Max(0, EditorGUILayout.FloatField ("マジックポイント", monster.MP));
		}

		//ドラゴンのパワーは固定なので設定しない
		if(monster.Type != SetMonsterStatus.MonsterType.Dragon){
			monster.Power = Mathf.Max(1, EditorGUILayout.FloatField ("パワー！", monster.Power));
		}

		//魔法使いはMP >= HP
		if(monster.Type == SetMonsterStatus.MonsterType.Witch){
			monster.MP = Mathf.Max (monster.MP, monster.HP);
		}

		EditorUtility.SetDirty( target );
	}

}