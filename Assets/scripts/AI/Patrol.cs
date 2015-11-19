using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

public class Patrol : MonoBehaviour 
{
	public Vector3 pointA;
	public Vector3 pointB;

	public float speed; 

	Vector3 target;

	// Use this for initialization
	void Start () 
	{
		target = pointA;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused == false) 
		{
			AiPatrol ();
		}
	}

	void OnDrawGizmos()
	{
		Debug.DrawLine (pointA, pointB);
	}

	void AiPatrol()
	{
		State _state = GetComponent<Entity> ().m_state;

		Entity _entity = GetComponent<Entity> ();

		Vector2 _vel = _entity.m_rigid2D.velocity; 

		_vel.x = 0;

		if(_state == State.ALIVE)
		{
			Facing _facing = GetComponent <Entity>().m_facing;
			if(target.x > transform.position.x )
			{
				_facing = Facing.RIGHT;
			}
			
			if(target.x < transform.position.x )
			{
				_facing = Facing.LEFT;
			}

			if(transform.position.x > target.x - 0.5f && transform.position.x < target.x + 0.5f)
			{
				switchTarget();
			}

			_vel.x = speed * (int)_facing;
		}

		_entity.m_rigid2D.velocity = _vel;
	}

	void switchTarget()
	{
		if (target == pointA) 
		{
			target = pointB;
		}
		else 
		{
			target = pointA;
		}

	}
}
