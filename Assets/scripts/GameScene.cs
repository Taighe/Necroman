using UnityEngine;
using System.Collections;


namespace nSCENE
{
	public class GameScene : MonoBehaviour
	{
		public float levelTime;
		static float s_levelTime;

		void Awake()
		{
			s_levelTime = levelTime;
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
			levelTime -= 1.0f * Time.deltaTime;

			if(levelTime < 0) levelTime = 0;

			s_levelTime = levelTime;

		}

		public static void AddLevelTime(float time)
		{
			s_levelTime += time;
		}

	}
	
}