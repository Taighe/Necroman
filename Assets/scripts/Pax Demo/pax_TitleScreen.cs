using UnityEngine;
using System.Collections;
using nSCENE;

public class pax_TitleScreen : MonoBehaviour 
{
	public Intro introCall;

	// Use this for initialization
	void Start () 
	{
		Scene.paused = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Submit")) 
		{
            Application.LoadLevel("lvl1_area1");
		}
	}
}
