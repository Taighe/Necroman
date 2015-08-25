using UnityEngine;
using System.Collections;
using nLEVELDATA;

namespace nDATACONTROL
{
	public class DataControl : MonoBehaviour 
	{
		public static DataControl control;
		public static LevelData levelData;

		// Use this for initialization
		void Awake () 
		{
			if (control == null) 
			{
				DontDestroyOnLoad (gameObject);
				control = this;
			} 
			else if(control != this)
			{
				Destroy(gameObject);
			}

		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}