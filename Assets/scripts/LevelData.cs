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
        public int soulFragmentRequirement;
		public bool unlocked;
        public bool completed;
        public bool passedRequirement;
		public int scoreSoulFragments;
		public bool[] collectedSouls;
		public bool medal;
		public string levelName;
		public string nextlevel;
		public bool timeAttackMode;
		public string trueLevelName;
        public int score;
		public float time;
        public int levelID;

        public void CopyData(LevelData data)
        {
            highScore = data.highScore;
            unlocked = data.unlocked;
            scoreSoulFragments = data.scoreSoulFragments;
            collectedSouls = data.collectedSouls;
            medal = data.medal;
            levelName = data.levelName;
            nextlevel = data.nextlevel;
            timeAttackMode = data.timeAttackMode;
            trueLevelName = data.trueLevelName;
            score = data.score;
            time = data.time;
            completed = data.completed;
            passedRequirement = data.passedRequirement;
            soulFragmentRequirement = data.soulFragmentRequirement;
        }
	}
}