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

		public string dataLink;
		LevelData data;

		void Awake()
		{
			s_levelTime = levelTime;
			if (dataLink == "")
				return;

			data = GameObject.Find (dataLink).GetComponent<LevelData> ();
			data.unlocked = true;
			DataControl.levelData = data;
		}
		
		// Update is called once per frame
		void Update () 
		{
			if(Input.GetButtonDown("Submit"))
			{
				Scene.paused = !Scene.paused;
			}

			if(Input.GetButtonDown("Cancel"))
			{
				Application.LoadLevel("levelSelectMenu_wip00");
			}

			if (Scene.paused)
				return;

			levelTime = s_levelTime;
			levelTime += 1.0f * Time.deltaTime;

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
	}
	
}