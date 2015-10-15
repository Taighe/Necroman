using UnityEngine;
using System.Collections;

public class customGUILayer : MonoBehaviour 
{
	public GUIManager m_guiManager;
	public GameObject m_layer;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_layer.SetActive(true);

		if (m_guiManager.m_currentMenu != m_layer) 
		{
			m_layer.SetActive(false);
		}
	}
}
