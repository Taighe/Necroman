using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using nDATACONTROL;
using nLEVELDATA;

public class LevelSelector : MonoBehaviour 
{
	LevelSelect m_level;
	public EventSystem m_event;
	public float speed;
	public GameObject worldCanvas;
	public GameObject modeSelect;

	Vector3 m_origin;
	float m_startTime;
	GameObject m_lastTarget;

	// Use this for initialization
	void Start () 
	{
        Time.timeScale = 1.0f;
        //m_translation = GetComponent<Translation> ();
		m_origin = transform.position;
		m_startTime = Time.time;

        m_event.SetSelectedGameObject(m_event.firstSelectedGameObject);

        GetComponent<Translation>().SetTranslate(transform.position, m_event.firstSelectedGameObject.transform.position);
        if (GameObject.Find(DataControl.control.levelData.levelName) != null)
        {
            GameObject _obj = GameObject.Find(DataControl.control.levelData.levelName);
            m_event.SetSelectedGameObject(_obj);
        }

        m_lastTarget = m_event.currentSelectedGameObject;
        transform.position = m_lastTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetButtonDown("Cancel") && worldCanvas.activeInHierarchy)
        {
            Application.LoadLevel("splash_screen");
        }
        
        if (Input.GetButtonDown ("Cancel")) 
		{
			worldCanvas.SetActive(true);
			modeSelect.SetActive(false);
			m_event.SetSelectedGameObject(m_lastTarget);
		}

		//float delta = Time.time - m_startTime;  
		//float distanceCovered = delta / speed; 
		Vector3 currentPos = transform.position;

        if (m_event.currentSelectedGameObject.GetComponent<LevelData>() != null)
        {
            DataControl.control.levelName = m_event.currentSelectedGameObject.GetComponent<LevelData>().levelName;
        }
            
        GameObject _target = m_event.currentSelectedGameObject;

		if (worldCanvas.activeInHierarchy == false)
			return;

        GetComponent<Translation>().SetTranslate(transform.position, _target.transform.position);

        GetComponent<Translation>().Translate();

		m_lastTarget = _target;

	}

	public void LoadLevel()
	{
        DataControl.control.GetComponent<LevelData>().CopyData(DataControl.control.levelData);
        DataControl.control.levelData = DataControl.control.GetComponent<LevelData>();
        DataControl.control.levelData.highScore = DataControl.control.levelData.score;
        Application.LoadLevel (DataControl.control.levelName);
	}
}
