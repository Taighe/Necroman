using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nSCENE;

public class GUIManager : MonoBehaviour 
{
	public GameObject scene;
	Text[] guiElements;
	GameObject m_pauseMenu;
	Image m_lives;

	void Awake()
	{
		guiElements = GetComponentsInChildren<Text> ();
		m_pauseMenu = transform.GetChild (1).gameObject;
		m_lives = transform.GetChild (2).GetComponent<Image> ();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//guiElements[0].text = "Time " + scene.GetComponent<GameScene>().levelTime / 60;
		//guiElements[1].enabled = Scene.paused;
		m_pauseMenu.SetActive(Scene.paused);
		//m_lives.fillAmount = 
	}
}
