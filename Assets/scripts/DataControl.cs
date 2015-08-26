using UnityEngine;
using System.Collections;
using nLEVELDATA;
using System;
using System.Runtime.Serialization;
using System.IO;

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