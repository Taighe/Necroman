using UnityEngine;
using System.Collections;

public class pax_TitleScreen : MonoBehaviour 
{
	public Intro introCall;

	// Use this for initialization
	void Start () 
	{

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
