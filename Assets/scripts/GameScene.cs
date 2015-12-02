using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nCOLLECTABLE;

namespace nSCENE
{
	public class GameScene : MonoBehaviour
	{
		public float levelTime;
		static float s_levelTime;
		public static GameScene gameScene;
		public int totalSoulFragments;
		public int currentSoulFragments;
        public int score;
		public GameObject currentCheckpoint;
        public string sceneName;
		public bool IsMidLevel;
        public bool HasReset;
        public bool NoDataControl;
        //public int LevelID;
        int m_startScore;

		public GameObject player;

		public string dataLink;

		DataControl data;

		float startTime;

		bool m_isGameOver = false;

		void Awake()
		{
			if(gameScene == null)
			{
				gameScene = this;
			}

            if (NoDataControl == true)
            {
                LocalLevel();
                return;
            }

            if(!IsMidLevel)
            {
                DataControl.control.levelData.score = 0;
            }

            //levelTime = DataControl.control.levelData.time;

			s_levelTime = levelTime;
			startTime = Time.time;

            score = DataControl.control.levelData.score;

            int currentSoulsCollected = 0;
			for(int i = 0; i < totalSoulFragments; i++)
			{
				GameObject _collectables = gameScene.gameObject.transform.GetChild(0).gameObject;
				_collectables.transform.GetChild(i).GetComponent<Collectable>().IsCollected = DataControl.control.levelData.collectedSouls[i];
               
                if(DataControl.control.levelData.collectedSouls[i] == true)
                {
                    _collectables.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4(1,1,1, 0.2f);
                    currentSoulsCollected++;
                }
			}

            DataControl.control.levelData.scoreSoulFragments = currentSoulsCollected;

		}

        void LocalLevel()
        {
            s_levelTime = levelTime;
            startTime = Time.time;
        }

		// Update is called once per frame
		void Update () 
		{
			if (Scene.paused) 
			{
				Time.timeScale = 0;
			}
			else Time.timeScale = 1;

			levelTime = s_levelTime;
			levelTime -= Time.deltaTime;

			s_levelTime = levelTime;

		}

		public static void AddLevelTime(float time)
		{
			s_levelTime += time;
		}

		public static float GetLevelTime()
		{
			return s_levelTime;
		}

		public void SetGameOver()
		{
			m_isGameOver = true;
            DataControl.control.levelData.time = levelTime;
            DataControl.control.levelData.score = 0;
		}

		public bool IsGameOver()
		{
			return m_isGameOver;
		}
	}
}