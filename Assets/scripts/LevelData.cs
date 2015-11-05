using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nDATACONTROL;
using nCOLLECTABLE;

namespace nLEVELDATA
{
	public class LevelData : MonoBehaviour 
	{
		public float highScore;
		public bool unlocked;
		public int scoreSoulFragments;
		public bool[] collectedSouls;
		public bool medal;
		public string levelName;
		public string nextlevel;
		public bool timeAttackMode;
		public string trueLevelName;
        public int score;
		public float time;

        void OnLevelWasLoaded(int index)
        {
            if (index == 1) 
            {
                scoreSoulFragments = 0;
                collectedSouls = new bool[10];
				score = 0;
                time = 301;
            }
            
        }

	}
}