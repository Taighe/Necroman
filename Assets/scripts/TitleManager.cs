
using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour 
{
	public Animator m_anim;

	// Use this for initialization
	void Start () 
	{

	}
	
	public void NewGame()
	{
		if(m_anim != null) m_anim.SetBool ("Start", true);

		gameObject.SetActive (false);
	}

	public void Continue()
	{

	}

	public void Quit()
	{
		Application.Quit ();
	}
}
