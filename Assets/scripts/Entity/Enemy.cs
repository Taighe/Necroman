using UnityEngine;
using System.Collections;
using nENTITY;
using nATTACK;
using nSCENE;

public class Enemy : Entity 
{
	public int hitPoints;
	public int boneValue;
	public bool IsRESPAWNABLE;
    public GameObject p_explosion;
	
	public GameObject p_attack;
	GameObject m_attack;
	Translation m_translate;
	Vector3 m_spawnPoint;
	Vector3 m_deathPoint;
	Player m_player;
	bool IsRESPAWNING;

	// Use this for initialization
	void Start () 
	{
		SetState (m_state, ref m_state);
		m_translate = gameObject.GetComponent<Translation> ();
		m_spawnPoint = transform.position;
		m_translate.SetTranslate (m_spawnPoint, m_spawnPoint);
		m_player = GameScene.gameScene.player.GetComponent<Player> ();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player" && m_team == Team.HOSTILE && m_state == State.ALIVE)
		{
			if(collision.contacts[0].normal.y < 0)
            {
                Damaged(1);
                GameScene.gameScene.player.GetComponent<Player>().Hop(GameScene.gameScene.player.GetComponent<Player>().boostJump);
                //
            }
            else
            {
                collision.gameObject.GetComponent<Entity>().Damaged(1);
            }
		}
	}

	// Update is called once per frame
	new void Update () 
	{
		GetComponent<Entity> ().Update ();
		if (m_state == State.DEATH) 
		{
			if(m_player.RespawnSignal() )
			{
                transform.position = m_spawnPoint;
                SetState(State.ALIVE, ref m_state);
			}
		}

		if (m_velocity.x > 0)
			m_facing = Facing.RIGHT;

		if (m_velocity.x < 0)
			m_facing = Facing.LEFT;

		ChangeInFacing ();
	}

	public override void Die()
	{
		SetState (State.DEATH, ref m_state);
	}

	public override void Damaged(int damage)
	{
		hitPoints -= damage;
		if(hitPoints <= 0)
		{
			Die ();
		}
	}

	public void Respawn()
	{
		//IsRESPAWNING = true;
        transform.position = m_spawnPoint;
	}

	bool SetState(State state, ref State address)
	{
        m_state = state;
        switch (state) 
		{
			case State.ALIVE:
			{
				//m_rigid2D.isKinematic = true;
				address = state;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
				return true; 
			}
			case State.DEATH:
			{
				//gameObject.layer = 10;
				//m_rigid2D.isKinematic = false;
                Instantiate(p_explosion, transform.position, transform.rotation);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

                //Destroy(gameObject);
				
                return true;
			}
		}
		
		return false;
	}
	
}
