using UnityEngine;
using System.Collections;
using nSCENE;

public class pax_endScene : MonoBehaviour 
{
	public float timer;
	public float delay;

	// Use this for initialization
	void Start () 
	{
		Scene.paused = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1.0f *Time.deltaTime;

		if (Input.GetButtonDown ("Submit"))
			Application.LoadLevel ("company_screen");

		if (timer > delay) 
		{
			Application.LoadLevel("company_screen");
		}
	}
}
