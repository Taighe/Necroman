using UnityEngine;
using System.Collections;
using nSCENE;

public class SoulParticle : MonoBehaviour
{
	GameObject m_player;
	Translation m_translate;

	// Use this for initialization
	void Start () 
	{
		m_player = GameScene.gameScene.player;
		m_translate = GetComponent<Translation> ();
		m_translate.m_timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 _pos = m_player.transform.position;

		m_translate.SetTranslate (transform.position, _pos);

		if (m_translate.Translate () >= m_translate.speed) 
		{
			Destroy(gameObject);
		}
	}
}
