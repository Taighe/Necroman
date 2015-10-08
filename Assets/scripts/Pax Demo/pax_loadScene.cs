using UnityEngine;
using System.Collections;

public class pax_loadScene : MonoBehaviour 
{
	public string sceneName;

	public void LoadLevel()
	{
		Application.LoadLevel (sceneName);
	}
}
