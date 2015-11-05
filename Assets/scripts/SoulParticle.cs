using UnityEngine;
using System.Collections;
using nSCENE;

public class SoulParticle : MonoBehaviour
{
	public GameObject remnant;
	public GameObject m_target;
	Translation m_translate;
    Vector2 m_offset;
    Rect m_rect;
    public float size;
    bool m_collect = false;
	public float timer;
	public float delay;

	// Use this for initialization
	void Start () 
	{
		m_translate = GetComponent<Translation> ();
        m_rect = new Rect(transform.position, new Vector2(size, size));
        m_rect.center = transform.position;
	}

	public void SetTarget(GameObject target, Vector2 offset)
	{
		m_target = target;
        m_offset = offset;
        
		if (m_target.gameObject.tag == "Player") gameObject.tag = "SoulCollect";
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.tag == "SoulCollect" && collider.gameObject.tag == "Player")
        { 
            SetTarget(collider.gameObject, new Vector2(0,0));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));
    }

	// Update is called once per frame
	void Update ()
	{
        GameObject _player = GameScene.gameScene.player; 
        if (m_rect.Contains(_player.transform.position, true) &&_player.GetComponent<Player>().IsAlive())
        {
            gameObject.tag = "SoulCollect";
            SetTarget(GameScene.gameScene.player, new Vector2(0, 0));
        }
            
        if (m_target == null)
			return;

        Vector3 _offset = new Vector3(m_offset.x, m_offset.y, 0);
		Vector3 _pos = m_target.transform.position + _offset;

		m_translate.SetTranslate (transform.position, _pos);

		m_translate.Translate ();

        if (m_target != null)
        {
            if (m_target.gameObject.tag == "Player" && gameObject.tag == "SoulCollect" && m_collect == false)
            {
                GameScene.gameScene.player.GetComponent<Player>().AddSouls(1);
                m_collect = true;

				timer += 1.0f * Time.deltaTime;

				if(timer >= delay)
				{
					Destroy(gameObject);
				}
            }
        }

		if (m_translate.AtDestination()) 
		{
            if (m_target.gameObject.tag == "RemnantGuide")
            {
                GameObject _remnant = (GameObject)Instantiate(remnant, transform.GetChild(0).position, transform.rotation);
                GameScene.gameScene.player.GetComponent<Player>().AddRemnant(_remnant);
            }

			Destroy(gameObject);
		}
	}
}
