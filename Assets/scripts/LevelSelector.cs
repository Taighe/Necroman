using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using nDATACONTROL;

public class LevelSelector : MonoBehaviour 
{
	Translation m_translation;
	LevelSelect m_level;
	public EventSystem m_event; 
	public float speed;
	public GameObject worldCanvas;

	Vector3 m_origin;
	float m_startTime;
	GameObject m_lastTarget;

	// Use this for initialization
	void Start () 
	{
		m_translation = GetComponent<Translation> ();
		m_origin = transform.position;
		m_startTime = Time.time;

		GameObject _obj = GameObject.Find (DataControl.control.levelData.levelName);
		m_event.SetSelectedGameObject (_obj);
		m_lastTarget = m_event.currentSelectedGameObject;
		transform.position = m_lastTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float delta = Time.time - m_startTime;  
		float distanceCovered = delta / speed; 
		Vector3 currentPos = transform.position;
		GameObject _target = m_event.currentSelectedGameObject;

		if(currentPos == _target.transform.position)
		{
			m_startTime = Time.time;
			m_origin = _target.transform.position;
		}

		currentPos = Vector3.Lerp (m_origin, _target.transform.position, distanceCovered);
		transform.position = currentPos;
		m_lastTarget = _target;
	}
}
