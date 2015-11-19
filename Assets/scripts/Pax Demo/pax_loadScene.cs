using UnityEngine;
using System.Collections;

public class pax_loadScene : MonoBehaviour 
{
	public string sceneName;

	void Start()
	{
		Cursor.visible = false;
	}

	public void LoadLevel()
	{
		Application.LoadLevel (sceneName);
	}
}
