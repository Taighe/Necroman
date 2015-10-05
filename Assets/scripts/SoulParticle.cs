using UnityEngine;
using System.Collections;
using nSCENE;

public class SoulParticle : MonoBehaviour
{
	public GameObject remnant;
	GameObject m_target;
	Translation m_translate;

	// Use this for initialization
	void Start () 
	{
		m_translate = GetComponent<Translation> ();
		m_translate.m_timer = 0;
	}

	public void SetTarget(GameObject target)
	{
		m_target = target;
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 _pos = m_target.transform.position;

		m_translate.SetTranslate (transform.position, _pos);

		if (m_translate.Translate () >= m_translate.speed) 
		{
			if(gameObject.tag == "Soul")
			{
				GameObject _remnant = (GameObject)Instantiate (remnant, transform.position, transform.rotation);
				GameScene.gameScene.player.GetComponent<Player>().AddRemnant(_remnant);
			}

			Destroy(gameObject);
		}
	}
}
