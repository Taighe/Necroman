using UnityEngine;
using System.Collections;
using nSCENE;

public class SoulParticle : MonoBehaviour
{
	public GameObject remnant;
	public GameObject m_target = null;
	Translation m_translate;
    Vector2 m_offset;
    Rect m_rect;
    public float size;
    bool m_collect = false;
	public float timer;
	public float delay;
    public bool m_createRemnant;
    bool m_projectileMode;
    float m_projectileSpeed;
    
    float m_recallDistance;

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
        Player _player = collider.gameObject.GetComponent<Player>();
        
        if(collider.gameObject.tag == "FreePlatform" && m_target == null)
        {
            SetTarget(gameObject, Vector2.zero);
            m_createRemnant = true;
        }

        if(!m_projectileMode)
        {
            if (m_target == null && collider.gameObject.tag == "Player" && _player.m_state == nENTITY.State.ALIVE)
            {
                SetTarget(collider.gameObject, new Vector2(0, 0));
            }
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

        //if (m_rect.Contains(_player.transform.position, true) &&_player.GetComponent<Player>().IsAlive())
        //{
        //    gameObject.tag = "SoulCollect";
        //    SetTarget(GameScene.gameScene.player, new Vector2(0, 0));
        //}
        
        //Projectile Mode
        if (m_projectileMode)
        {
            Vector3 position = transform.position;
            position.x += m_projectileSpeed * Time.deltaTime;
            transform.position = position;
            
            if(m_projectileSpeed > 0 && transform.position.x >= m_recallDistance || m_projectileSpeed < 0 && transform.position.x <= m_recallDistance)
            {
                m_projectileMode = false;
                m_projectileSpeed = 0;
            }
        }
        else
        {
            if(Input.GetButtonDown("Reset") )
            {
                m_target = GameScene.gameScene.player;
                gameObject.tag = "SoulCollect";
            }
        }
        
        //No target don't do anything
        if (m_target == null)
			return;
        //

        Vector3 _offset = new Vector3(m_offset.x, m_offset.y, 0);
		Vector3 _pos = m_target.transform.position + _offset;

		m_translate.SetTranslate (transform.position, _pos);

		m_translate.Translate ();

        timer += 1.0f * Time.deltaTime;

        if (timer >= delay)
        {
            Die();
        }

        if (m_target != null)
        {
            m_projectileMode = false;
            if (gameObject.tag == "SoulCollect" && m_collect == false && m_createRemnant == false)
            {
                GameScene.gameScene.player.GetComponent<Player>().AddSouls(1);
                m_collect = true;
            }

            if (m_translate.AtDestination())
            {
                if (m_target.gameObject.tag == "RemnantGuide" || m_createRemnant)
                {
                    GameObject _remnant = (GameObject)Instantiate(remnant, transform.position, transform.rotation);
                    GameScene.gameScene.player.GetComponent<Player>().AddRemnant(_remnant);
                }

                Die();
            }
        }
	}

    public void Die()
    {
        Destroy(gameObject);
    }

    public bool IsBeingUsed()
    {
        CircleCollider2D circle = GetComponent<CircleCollider2D>();

        if (circle)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, circle.radius, Vector2.zero, 1.0f, 1 << LayerMask.NameToLayer("SoulInteract"));
            if (hit.collider != null && hit.collider.isTrigger)
            {
                return true;
            }
                
        }

        return false;
    }

    public void SetToProjectile(float speed, float recallDistance)
    {
        m_projectileMode = true;
        m_projectileSpeed = speed;
        m_recallDistance = transform.position.x + recallDistance;
    }
}
