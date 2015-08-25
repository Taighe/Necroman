using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nSCENE;

public class GUIManager : MonoBehaviour 
{
	public GameObject scene;
	Text[] guiElements;

	void Awake()
	{
		guiElements = GetComponentsInChildren<Text> ();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiElements[0].text = "Time " + scene.GetComponent<GameScene>().levelTime / 60;
		guiElements[1].enabled = Scene.paused;
	}
}
