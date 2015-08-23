using UnityEngine;
using System.Collections;
using nENTITY;
using nATTACK;

public class Enemy : Entity 
{
	public int hitPoints;
	public int boneValue;

	public GameObject p_attack;
	GameObject m_attack;
	
	// Use this for initialization
	void Start () 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player" && m_state == State.ALIVE)
		{
			collision.gameObject.GetComponent<Entity>().Damaged(1);
		}
	}

	// Update is called once per frame
	void Update () 
	{

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

	bool SetState(State state, ref State address)
	{
		switch (state) 
		{
			case State.ALIVE:
			{
				MeshRenderer _mesh = GetComponent<MeshRenderer>();
				_mesh.enabled = true;
				BoxCollider2D _box = GetComponent<BoxCollider2D>();
				_box.enabled = true;
				m_rigid2D.isKinematic = true;
				address = state;
				return true; 
			}
			case State.DEATH:
			{

				m_rigid2D.isKinematic = false;
				address = state;
				return true;
			}
		}
		
		return false;
	}
	
}
