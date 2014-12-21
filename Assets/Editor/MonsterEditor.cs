using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(Monster))]
public class MonsterEditor : Editor
{

	public override void OnInspectorGUI() {
		Monster monster = target as Monster;

		//入力されたモンスターの種類を設定
		monster.Type = (Monster.MonsterType)EditorGUILayout.EnumPopup( "モンスターの種類", monster.Type);

		//共通の注記
		EditorGUILayout.HelpBox("体力とパワーは0に設定できません。", MessageType.Info, true );

		//各タイプ毎に注記を表示
		if(monster.Type == Monster.MonsterType.Warrior){
			EditorGUILayout.HelpBox("Warriorは魔法が使えないのマジックポイントは設定できません", MessageType.Info, true );
		}
		else if(monster.Type == Monster.MonsterType.Witch){
			EditorGUILayout.HelpBox("Witchはマジックポイントを0にできません。\nまた、体力より低いマジックポイントも設定できません。", MessageType.Info, true );
		}
		else if(monster.Type == Monster.MonsterType.Dragon){
			EditorGUILayout.HelpBox("Dragonのパワーは固定なので設定できません", MessageType.Info, true );
		}


		//HPはどのタイプでも設定
		monster.HP = EditorGUILayout.FloatField ("体力", monster.HP);

		//戦士はMPが0なので設定しない
		if(monster.Type != Monster.MonsterType.Warrior){
			monster.MP = EditorGUILayout.FloatField ("マジックポイント", monster.MP);
		}

		//ドラゴンのパワーは固定なので設定しない
		if(monster.Type != Monster.MonsterType.Dragon){
			monster.Power = EditorGUILayout.FloatField ("パワー！", monster.Power);
		}

		EditorUtility.SetDirty( target );
	}

}