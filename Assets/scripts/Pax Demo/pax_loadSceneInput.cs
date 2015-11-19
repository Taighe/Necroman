using UnityEngine;
using System.Collections;

public class pax_loadSceneInput : MonoBehaviour 
{
	public string sceneName;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Submit")) 
		{
			Application.LoadLevel(sceneName);
		}
	}
}
