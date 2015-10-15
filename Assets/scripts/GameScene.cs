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
		public GameObject currentCheckpoint;

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

			s_levelTime = levelTime;
			startTime = Time.time;

			currentSoulFragments = DataControl.control.levelData.scoreSoulFragments;

			if(DataControl.control.levelData.collectedSouls.Length == 0)
			{
				DataControl.control.levelData.collectedSouls = new bool[totalSoulFragments];
			}

			for(int i = 0; i < totalSoulFragments; i++)
			{
				GameObject _collectables = gameScene.gameObject.transform.GetChild(1).gameObject;
				_collectables.transform.GetChild(i).GetComponent<Collectable>().IsCollected = DataControl.control.levelData.collectedSouls[i];
			}

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

			if (levelTime <= 0) 
			{
				Time.timeScale = 1;
				Application.LoadLevel("end_screen");
			}
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
		}

		public bool IsGameOver()
		{
			return m_isGameOver;
		}
	}
}