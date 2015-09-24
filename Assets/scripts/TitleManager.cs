using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using nDATACONTROL;

public class TitleManager : MonoBehaviour 
{
	public Animator m_anim;
	public EventSystem m_eventSystem;

	Button m_continue;

	// Use this for initialization
	void Start () 
	{
		m_continue = transform.GetChild (2).GetComponent<Button>();
	}

	void Update()
	{
		if (DataControl.control.GetSaveData()) 
		{
			m_continue.interactable = true;
			return;
		}

		m_continue.interactable = false;
	}

	public void NewGame()
	{
		if(m_anim != null) m_anim.SetBool ("Start", true);

		gameObject.SetActive (false);
		m_eventSystem.gameObject.SetActive (false);
	}
	
	public void Continue()
	{
		DataControl.control.Load ();
		Application.LoadLevel ("levelSelectMenu_wip00");
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void DeleteData()
	{
		DataControl.control.Delete ();
	}
}
