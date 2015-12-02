using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using nDATACONTROL;
using nLEVELDATA;

public class LevelSelect : MonoBehaviour 
{
    public GameObject canvas;

	public EventSystem m_event;
    
    [Header("Links")]
    public GameObject[] prev;
    public GameObject[] next;

    LevelData m_data;
    LineRenderer[] m_nextLines;
    
	void Start()
	{
        m_data = GetComponent<LevelData>();
		canvas.transform.GetChild (0).gameObject.SetActive (false);

        m_nextLines = new LineRenderer[next.Length];

        for (int i = 0; i < m_nextLines.Length; i++)
        {
            GameObject p = new GameObject();
            GameObject emptyObject = (GameObject)Instantiate(p, transform.position, transform.rotation);
            emptyObject.transform.parent = transform;
            m_nextLines[i] = emptyObject.AddComponent<LineRenderer>();
            m_nextLines[i].SetColors(Color.white, Color.white);
            m_nextLines[i].SetWidth(0.1f, 0.1f);
            m_nextLines[i].materials[0].shader = GetComponent<Image>().material.shader;
        }

	}

    void Update()
    {
        Button button = GetComponent<Button>();
        button.interactable = m_data.unlocked;

        RenderLinks();
    }

	public void ModeSelect()
	{
        if(DataControl.control.reflevelData.completed == false)
        {
            if (DataControl.control.reflevelData.passedRequirement == false)
            {
                if (DataControl.control.m_worldFragments >= DataControl.control.levelData.soulFragmentRequirement )
                {
                    DataControl.control.reflevelData.passedRequirement = true;

                    return;
                }

            }
            else
            {
                Application.LoadLevel(DataControl.control.levelData.levelName);
                return;
            }   
            
        }
            
        GameObject _modeSelect = canvas.transform.GetChild (0).gameObject;
		_modeSelect.SetActive (true);
		m_event.SetSelectedGameObject (_modeSelect.transform.GetChild (0).gameObject);
		Button _timeAttack = _modeSelect.transform.GetChild (1).gameObject.GetComponent<Button> ();
		_timeAttack.interactable = m_data.timeAttackMode;
		canvas.transform.GetChild (0).gameObject.SetActive (true);
	}

    void OnDrawGizmos()
    {
        for (int i = 0; i < next.Length; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, next[i].transform.position);
        }
    }

    void RenderLinks()
    {
        Image _sprite = GetComponent<Image>();
        for (int i = 0; i < next.Length; i++ )
        {
            m_nextLines[i].SetPosition(0, transform.position);
            m_nextLines[i].SetPosition(1, next[i].transform.position);
            
            if(next[i].GetComponent<LevelData>().unlocked)
            {
                m_nextLines[i].enabled = true;
            }
            else
            {
                m_nextLines[i].enabled = false;
            }

        }

        if (prev.Length > 0)
        {
            if (prev[0].GetComponent<LevelData>().unlocked)
            {
                _sprite.enabled = true;
            }
            else
            {
                _sprite.enabled = false;
            }

        }
    }
}