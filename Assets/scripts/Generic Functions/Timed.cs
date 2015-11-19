using UnityEngine;
using System.Collections;
using nSCENE;

public class Timed : MonoBehaviour 
{
	public float offDelay;
	public float onDelay;

	public bool active;

	public GameObject timedObject;

	public float m_timer;
	float m_delay;

	// Use this for initialization
	void Start () 
	{
		m_delay = offDelay;
		
		if (active)
			m_delay = onDelay;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused)
			return;

		m_timer += 1.0f * Time.deltaTime;

		if (m_timer >= m_delay ) 
		{
			active = !active;

			m_delay = offDelay + m_timer;
			
			if (active)
				m_delay = onDelay + m_timer;
		}

		timedObject.SetActive (active);
	}
}
