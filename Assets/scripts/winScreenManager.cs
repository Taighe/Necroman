using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nDATACONTROL;

public class winScreenManager : MonoBehaviour 
{ 
	public GameObject p_soulFragment;

	public GameObject p_player;

	public float timer;

	public float delay;

	public float radius;

	public Text m_percentage;

	public int maxSoulFragments;
	
	int m_count = 0;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= delay && m_count < 5 )
		{
			GameObject soulFragment = (GameObject)Instantiate(p_soulFragment, p_player.transform.position, p_player.transform.rotation);
			timer = 0;
			m_count += 1;
		}

		float percent = ((float)m_count / (float)maxSoulFragments) * 100;

		m_percentage.text = "" + percent + " %";
	}
}
