using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	private float _hp;
	public  float  HP{
		get{return _hp;}
		set{_hp = value;}
	}

	private float _mp;
	public  float  MP{
		get{return _mp;}
		set{_mp = value;}
	}
	private float _power; 
	public  float  Power{
		get{return _power;}
		set{_power = value;}
	}

}
