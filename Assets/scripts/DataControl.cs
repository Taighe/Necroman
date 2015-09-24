using UnityEngine;
using System.Collections;
using nLEVELDATA;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using nCOLLECTABLE;

namespace nDATACONTROL
{
	[Serializable]
	public struct SerialLevelData
	{
		public int soulFragment;
		public bool[] collectables;
		public bool unlocked;
	}
	
	[Serializable]
	public class SaveData
	{
		public SerialLevelData[] m_data;
		
		public SaveData()
		{
			m_data = new SerialLevelData[4];
		}
	}

	public class DataControl : MonoBehaviour 
	{
		public static DataControl control;
		public LevelData levelData;

		public LevelData startlevel;
		public int numOflevels;

		// Use this for initialization
		void Awake () 
		{
			if (control == null) 
			{
				DontDestroyOnLoad (gameObject);
				levelData = startlevel;
				control = this;
			} 
			else if(control != this)
			{
				Destroy(gameObject);
			}

		}

		public bool Save()
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open ("/save.dat", FileMode.Create);

			SaveData data = new SaveData ();

			for(int i = 0; i < numOflevels; i++)
			{
				SerialLevelData _leveData = new SerialLevelData ();
				
				_leveData.soulFragment = transform.GetChild(i).GetComponent<LevelData>().scoreSoulFragments;
				_leveData.unlocked = transform.GetChild(i).GetComponent<LevelData>().unlocked;

				data.m_data[i] = _leveData;
			}

			bf.Serialize (file, data);
			file.Close();
			return true;

		}

		public bool Load()
		{
			if (File.Exists ("/save.dat")) 
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open ("/save.dat", FileMode.Open);
				
				SaveData data = (SaveData)bf.Deserialize(file);

				for(int i = 0; i < numOflevels; i++)
				{
					transform.GetChild(i).GetComponent<LevelData>().scoreSoulFragments = data.m_data[i].soulFragment; 
					transform.GetChild(i).GetComponent<LevelData>().unlocked = data.m_data[i].unlocked;  
				}

				file.Close();

				return true;
			}

			return false;
		}

		public bool GetSaveData()
		{
			if (File.Exists ("/save.dat"))
				return true;

			return false;
		}

		public bool Delete()
		{
			if (File.Exists ("/save.dat"))
			{
				File.Delete("/save.dat");
				return true;
			}

			return false;
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}


}