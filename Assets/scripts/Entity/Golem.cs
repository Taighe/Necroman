using UnityEngine;
using System.Collections;
using nENTITY;
using nATTACK;
using nSCENE;

public class Golem : Enemy 
{
	// Use this for initialization
	void Start () 
	{
		SetState (m_state, ref m_state);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsPaused ())
			return;

		GetComponent<Entity> ().Update ();
		ChangeInFacing ();
	}
	
	public override void Die()
	{
		SetState (State.DEATH, ref m_state);
	}

	bool SetState(State state, ref State address)
	{
		switch (state) 
		{
			case State.ALIVE:
			{
				gameObject.layer = 0;
				address = state;
				return true; 
			}
			case State.DEATH:
			{
				m_team = Team.NEUTRAL;
				address = state;
				return true;
			}
		}
		
		return false;
	}
	
}
