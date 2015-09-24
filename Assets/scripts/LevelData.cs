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

		// Use this for initialization
		void Awake () 
		{

		}

		// Update is called once per frame
		void Update () 
		{

		}
	}
}