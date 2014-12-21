using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class MonsterDataMaker: AssetPostprocessor{

	private const string COMMAND_NAME = "Tools/Create/Monster Data(再生中に実行)";

	private const string DATA_PATH = "Assets/Resources/Data/";
	private const string SETTING_SCENE_DIRECTORY_PATH = "Assets/Scene/Setting";

	private const string ASSET_EXTENSION = ".asset";
	private const string EXCEL_EXTENSION = ".xls";


	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {

			string directoryName = System.IO.Path.GetDirectoryName (asset);
			if(directoryName == SETTING_SCENE_DIRECTORY_PATH){
				string sceneName = System.IO.Path.GetFileNameWithoutExtension (asset);
				Create (sceneName);
			}
		}
	}

	[MenuItem(COMMAND_NAME)]
	public static void CreateFromeMenu(){
		Create ();
	}

	private static void Create(string sceneName = null){

		if(sceneName == null){
			sceneName = Application.loadedLevelName;
		}

		//アセットデータ作成、既にあるものは削除。ファイル名は[シーン名].asset
		string dataPath = DATA_PATH + sceneName + ASSET_EXTENSION;
		MonsterData data = ScriptableObject.CreateInstance<MonsterData> ();
		AssetDatabase.DeleteAsset (dataPath);
		AssetDatabase.CreateAsset ((ScriptableObject)data, dataPath);

		//アセットデータをインスペクターから変更できないように
		data.hideFlags = HideFlags.NotEditable;

		//Projectも含めた全GameObjectを取得
		GameObject[] gameobjects = Resources.FindObjectsOfTypeAll<GameObject> ();
		foreach (GameObject gameobject in gameobjects) {

			//Hierarchyに設置されてるもの、かつ、SetMonsterStatusスクリプトを持ってるものを抽出
			if(gameobject.activeInHierarchy && gameobject.GetComponent<SetMonsterStatus>()){

				//SetMonsterStatusに設定されているデータ及び、位置と角度をMonsterDataのParamに登録
				MonsterData.Param param = new MonsterData.Param ();
				param.Type    = gameobject.GetComponent<SetMonsterStatus> ().Type;

				param.HP    = gameobject.GetComponent<SetMonsterStatus> ().HP;
				param.MP    = gameobject.GetComponent<SetMonsterStatus> ().MP;
				param.Power = gameobject.GetComponent<SetMonsterStatus> ().Power;

				param.Position = gameobject.transform.position;
				param.Rotation = gameobject.transform.rotation;

				data.list.Add (param);
			}
		}

		//保存
		ScriptableObject obj = AssetDatabase.LoadAssetAtPath (dataPath, typeof(ScriptableObject)) as ScriptableObject;
		EditorUtility.SetDirty (obj);

		Debug.Log (dataPath + "を作成");

	}

}