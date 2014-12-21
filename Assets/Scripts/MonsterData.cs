using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterData : ScriptableObject
{
	public List<Param> list = new List<Param> ();
	
	[System.SerializableAttribute]
	public class Param
	{
		public string GameObjectName;
		public SetMonsterStatus.MonsterType Type;
		public float HP, MP ,Power;
		public Vector3    Position;
		public Quaternion Rotation;
	}
}

