using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nLEVELDATA;

namespace nSCENE
{
	public class GameScene : MonoBehaviour
	{
		public float levelTime;
		static float s_levelTime;
		public static GameScene gameScene;
		public int currentSoulFragments;

		public GameObject player;

		public string dataLink;

		LevelData data;

		void Awake()
		{
			if(gameScene == null)
			{
				gameScene = this;
			}

			s_levelTime = levelTime;

			if (GameObject.Find (dataLink) == null)
				return;

			data = GameObject.Find (dataLink).GetComponent<LevelData> ();

			data.unlocked = true;
			DataControl.levelData = data;
		}
		
		// Update is called once per frame
		void Update () 
		{
			if (Scene.paused)
				return;

			levelTime = s_levelTime;
			levelTime += 0.5f * Time.smoothDeltaTime;

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

		public void Resume()
		{
			Scene.paused = false;
			Scene.buttonPressed = true;

		}
		
		public void Quit()
		{
			Scene.paused = false;
			Application.LoadLevel("levelSelectMenu_wip00");
		}
	}


}