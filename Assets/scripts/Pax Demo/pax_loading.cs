using UnityEngine;
using System.Collections;

public class pax_loading : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Submit"))
		{
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}
	}
}
