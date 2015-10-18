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
	}

	public void SetTarget(GameObject target)
	{
		m_target = target;
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.tag == "Soul" && collider.gameObject.tag == "Player")
        {
            gameObject.tag = "SoulCollect";
            SetTarget(collider.gameObject);
        }
    }

	// Update is called once per frame
	void Update ()
	{
		if (m_target == null)
			return;

		Vector3 _pos = m_target.transform.position;

		m_translate.SetTranslate (transform.position, _pos);

		m_translate.Translate ();

		if (m_translate.AtDestination()) 
		{
			if(gameObject.tag == "Soul")
			{
				GameObject _remnant = (GameObject)Instantiate (remnant, transform.position, transform.rotation);
				GameScene.gameScene.player.GetComponent<Player>().AddRemnant(_remnant);
			}

            if (m_target.gameObject.tag == "Player" && gameObject.tag == "SoulCollect")
			{
                GameScene.gameScene.player.GetComponent<Player>().AddSouls(1);
			}

			Destroy(gameObject);
		}
	}
}
