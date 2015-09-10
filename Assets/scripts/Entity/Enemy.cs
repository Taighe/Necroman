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
		if(collision.gameObject.tag == "Player" && m_state == State.ALIVE && collision.gameObject.GetComponent<Entity>().m_team == Team.HOSTILE)
		{
			collision.gameObject.GetComponent<Entity>().Damaged(1);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (m_state == State.DEATH) 
		{
			if(IsRESPAWNING )
			{
				if(m_translate.Translate() >= 1)
				{
					IsRESPAWNING = false;
					SetState(State.ALIVE, ref m_state);
					m_translate.m_timer = 0;
				}

				return;
			}

			m_deathPoint = transform.position;

			m_translate.SetTranslate(m_deathPoint, m_spawnPoint);

			if(m_player == null) return;

			if(m_player.RespawnSignal() )
			{
				if(m_player.m_respawnArea.Contains(transform.position) )
				{
					Respawn();
				}
			}
		}
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
		IsRESPAWNING = true;
		m_team = Team.PLAYER;
	}

	bool SetState(State state, ref State address)
	{
		switch (state) 
		{
			case State.ALIVE:
			{
				BoxCollider2D _box = GetComponent<BoxCollider2D>();
				gameObject.layer = 0;
				_box.enabled = true;
				m_rigid2D.isKinematic = true;
				address = state;
				return true; 
			}
			case State.DEATH:
			{
				gameObject.layer = 10;
				m_rigid2D.isKinematic = false;
				address = state;
				return true;
			}
		}
		
		return false;
	}
	
}
