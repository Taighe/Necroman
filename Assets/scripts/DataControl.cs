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
        public bool passedRequirement;
	}
	
	[Serializable]
	public class SaveData
	{
		public SerialLevelData[] m_levelData;
        
        //World Data
        public int m_worldFragments;

		public SaveData()
		{
            if(Application.loadedLevelName == "levelSelectMenu_wip00")
            {
                GameObject levels = GameObject.Find("World Canvas");
                m_levelData = new SerialLevelData[levels.transform.childCount];
            }

		}
	}

	public class DataControl : MonoBehaviour 
	{
		public static DataControl control; //Current instance of DataControl
		public LevelData levelData; //Copy of LevelData for the entered level
        public LevelData reflevelData; //Ref too level link
        public string levelName;

		public LevelData startlevel;
        public int m_worldFragments; //Total Fragments collected in the whole game

        SaveData m_data; //Gamedata collection

		// Use this for initialization
		void Awake () 
		{
			//Set control ref too itself
            if (control == null) 
			{
				DontDestroyOnLoad (gameObject);
                levelData = GetComponent<LevelData>();
				control = this;

                m_data = new SaveData();
			}
            else if (control != this) //If there is already an intance of this object in the scene destroy it
			{
				Destroy(gameObject);    
			}
            
            if(Application.loadedLevelName == "levelSelectMenu_wip00")
            {
                DataControl.control.LoadData();
            }
		}

		public bool Save()
		{
            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.dataPath + "/save.dat", FileMode.Create);

			SerialLevelData _levelData = new SerialLevelData ();

            LevelData output = DataControl.control.gameObject.GetComponent<LevelData>();
            _levelData.soulFragment = output.scoreSoulFragments;
            _levelData.passedRequirement = output.passedRequirement;

            if(output.score > levelData.highScore)
            {
                _levelData.score = output.score;
            }
            
            _levelData.collectables = output.collectedSouls;

            m_data.m_levelData[DataControl.control.levelData.levelID] = _levelData;
            
            //next level
            m_data.m_levelData[DataControl.control.levelData.levelID].unlocked = true;

            m_data.m_worldFragments = m_worldFragments;

			bf.Serialize (file, m_data);
			file.Close();
			return true;
		}

		public bool LoadLevelData(LevelData levelData)
		{
            if (File.Exists(Application.dataPath + "/save.dat")) 
			{
				BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + "/save.dat", FileMode.Open);
				
				SaveData data = (SaveData)bf.Deserialize(file);

                levelData.scoreSoulFragments = data.m_levelData[levelData.levelID].soulFragment;
                levelData.score = data.m_levelData[levelData.levelID].score;
                levelData.collectedSouls = data.m_levelData[levelData.levelID].collectables;
                levelData.passedRequirement = data.m_levelData[levelData.levelID].passedRequirement;
                
                if (levelData.unlocked == false)
                    levelData.unlocked = data.m_levelData[levelData.levelID].unlocked;  

				file.Close();

				return true;
			}

			return false;
		}

        public void LoadData()
        {
            GameObject levels = GameObject.Find("World Canvas");

            int _worldFragments = 0;

            for (int i = 0; i < levels.transform.childCount; i++)
            {
                LevelData _data = (LevelData)levels.transform.GetChild(i).GetComponent<LevelData>();
                LoadLevelData(_data);

                _worldFragments += _data.scoreSoulFragments;
            }

            m_worldFragments = _worldFragments;
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