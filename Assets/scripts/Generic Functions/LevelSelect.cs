using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour 
{

	public void LoadScene(string scene)
	{
		Application.LoadLevel (scene);
	}

}
