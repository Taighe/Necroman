using UnityEngine;
using System.Collections;

public class pax_noInputTimer : MonoBehaviour 
{
	public float timer;
	public float delay;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1.0f * Time.deltaTime;

		if (timer >= delay)
			Application.LoadLevel ("end_screen");

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)
		{
			ResetTimer ();
			return;
		}

		if(Input.GetButton("Jump"))
		{
			ResetTimer();
			return;
		}

		if(Input.GetButton("Reset"))
		{
			ResetTimer();
			return;
		}

		if(Input.GetButton("Submit"))
		{
			ResetTimer();
			return;
		}

		if(Input.GetButton("Cancel"))
		{
			ResetTimer();
			return;
		}
	}

	void ResetTimer()
	{
		timer = 0;
	}
}
