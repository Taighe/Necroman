using UnityEngine;
using System.Collections;

public class pax_noInputTimer : MonoBehaviour 
{
	public float timer;
	public float delay;

	string[] m_buttons;
	int m_size = 8;

	// Use this for initialization
	void Start () 
	{
		m_buttons = new string[m_size];
		m_buttons[0] = "Attack";
		m_buttons[1] = "Reset";
		m_buttons[2] = "Jump";
		m_buttons[3] = "Submit";
		m_buttons[4] = "Cancel";
		m_buttons[5] = "Reanimate";
		m_buttons[6] = "Pause";
		m_buttons[7] = "Peek";
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1.0f * Time.deltaTime;

		if (timer >= delay)
			Application.LoadLevel ("lvl1_area1");

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)
		{
			ResetTimer ();
			return;
		}

		for (int i = 0; i < m_size; i++) 
		{
			if(Input.GetButtonDown(m_buttons[i]))
			{
				ResetTimer();
				return;
			}
		}
	}

	void ResetTimer()
	{
		timer = 0;
	}
}
