using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace nLEVELDATA
{

	public class LevelData : MonoBehaviour 
	{
		float highScore;
		public bool locked;
		Button button;

		// Use this for initialization
		void Start () 
		{
			button = GetComponent<Button> ();
		}
		
		// Update is called once per frame
		void Update () 
		{
			button.interactable = locked;
		}
	}
}