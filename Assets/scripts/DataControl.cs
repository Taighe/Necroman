using UnityEngine;
using System.Collections;
using nLEVELDATA;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using nCOLLECTABLE;
using nSCENE;

namespace nDATACONTROL
{
	[Serializable]
	public struct SerialLevelData
	{
		public int soulFragment;
        public int score;
		public bool[] collectables;
		public bool unlocked;
	}
	
	[Serializable]
	public class SaveData
	{
		public SerialLevelData[] m_data;
		
		public SaveData()
		{
			m_data = new SerialLevelData[3];
		}
	}

	public class DataControl : MonoBehaviour 
	{
		public static DataControl control;
		public LevelData levelData;
        public string levelName;

		public LevelData startlevel;
		public int numOflevels;

        SaveData m_data;

		// Use this for initialization
		void Awake () 
		{
			if (control == null) 
			{
				DontDestroyOnLoad (gameObject);
                levelData = GetComponent<LevelData>();
				control = this;

                m_data = new SaveData();

			} 
			else if(control != this)
			{
				Destroy(gameObject);
			}

		}

		public bool Save(GameScene scene)
		{
			if(scene == null) 
                return false;

            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.dataPath + "/save.dat", FileMode.Create);

			SerialLevelData _leveData = new SerialLevelData ();

            LevelData output = DataControl.control.gameObject.GetComponent<LevelData>();
            _leveData.soulFragment = output.scoreSoulFragments;
           
            if(output.score > levelData.highScore)
            {
                _leveData.score = output.score;
            }
            
            _leveData.collectables = output.collectedSouls;

			m_data.m_data[scene.LevelID] = _leveData;
            //next level
            m_data.m_data[scene.LevelID + 1].unlocked = true;

			bf.Serialize (file, m_data);
			file.Close();
			return true;

		}

		public bool Load(LevelData levelData)
		{
            if (File.Exists(Application.dataPath + "/save.dat")) 
			{
				BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + "/save.dat", FileMode.Open);
				
				SaveData data = (SaveData)bf.Deserialize(file);

                levelData.scoreSoulFragments = data.m_data[levelData.levelID].soulFragment;
                levelData.score = data.m_data[levelData.levelID].score;
                levelData.collectedSouls = data.m_data[levelData.levelID].collectables;
                if (levelData.unlocked == false)
                    levelData.unlocked = data.m_data[levelData.levelID].unlocked;  

				file.Close();

				return true;
			}

			return false;
		}

		public bool GetSaveData()
		{
			if (File.Exists (Application.dataPath + "/save.dat"))
				return true;

			return false;
		}

		public bool Delete()
		{
            if (File.Exists(Application.dataPath + "/save.dat"))
			{
                File.Delete(Application.dataPath + "/save.dat");
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