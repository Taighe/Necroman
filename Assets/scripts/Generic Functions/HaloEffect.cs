using UnityEngine;
using System.Collections;

public class HaloEffect : MonoBehaviour 
{
    float m_startTime;
    float m_speed;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<ParticleSystem>().startSpeed = m_speed;
        
        m_speed += 2.0f * Time.deltaTime;
	}
}
