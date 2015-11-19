using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
    AudioClip m_bgMusic;

	// Use this for initialization
    void OnLevelWasLoaded(int level) 
    {
        GameObject _object = GameObject.Find("bg");
        if (_object != null)
        {
            m_bgMusic = GameObject.Find("bg").GetComponent<AudioSource>().clip;
        }

        GetComponent<AudioSource>().clip = m_bgMusic;
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
