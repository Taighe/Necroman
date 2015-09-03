using UnityEngine;
using System.Collections;

using nSCENE;

namespace nENTITY
{
	public enum Team
	{
		PLAYER = 0,
		HOSTILE,
		NEUTRAL,
	}

	public enum Facing
	{
		LEFT = -1,
		RIGHT = 1
	}

	public enum State
	{
		ALIVE = 0,
		DEATH,
	}

	public class Entity : MonoBehaviour 
	{
		public Facing m_facing;

		protected Rigidbody2D m_rigid2D;

		protected Vector2 m_collisionNormals;

		public State m_state;

		public Team m_team;
		public float maxFallSpeed;

		protected bool IsINTERACTABLE;
		public bool IsPLATFORM;

		Facing m_lastFacing; 

		float m_scaleX;

		public void OnCollisionStay2D(Collision2D collision)
		{
			Entity _entity = collision.gameObject.GetComponent<Entity> ();
			
			Vector2 norms = collision.contacts[0].normal;

			if (_entity != null && _entity.IsPLATFORM && norms.y < 0) 
			{
				return;
			}

			m_collisionNormals += norms;

			m_collisionNormals.x = Mathf.Clamp (m_collisionNormals.x, -1.0f, 1.0f);
			m_collisionNormals.y = Mathf.Clamp (m_collisionNormals.y, -1.0f, 1.0f);

		}

		public void OnCollisionEnter2D(Collision2D collision)
		{

		}

		public void OnCollisionExit2D(Collision2D collision)
		{

			m_collisionNormals = Vector2.zero;


		}

		public void OnTriggerExit2D(Collider2D collision)
		{
			if (IsPLATFORM) 
			{
				BoxCollider2D _collider = gameObject.GetComponent<BoxCollider2D>();
				_collider.enabled = true;
			}
		}

		// Use this for initialization
		public virtual void Awake()
		{
			m_rigid2D = GetComponent<Rigidbody2D> ();
			m_scaleX = transform.localScale.x;

			Vector3 scale = transform.localScale;
			scale.x = m_scaleX * (float)m_facing ;
			transform.localScale = scale;
		}

		public bool IsOnGround()
		{
			if(m_collisionNormals.y > 0)
			{
				return true;
			}

			return false;
		}

		public bool IsPaused () 
		{
			if (Scene.paused == true) 
			{
				m_rigid2D.Sleep ();
				return true;
			}
			m_rigid2D.WakeUp ();
			return false;
		}

		public void Update()
		{
			m_lastFacing = m_facing;

			Vector2 vel = m_rigid2D.velocity;
			if (m_rigid2D.velocity.y < maxFallSpeed) 
			{
				vel.y = maxFallSpeed;
			}
			
			m_rigid2D.velocity = vel;
		}

		public void ChangeInFacing()
		{
			if(m_facing != m_lastFacing)
			{
				Vector3 scale = transform.localScale;
				scale.x = m_scaleX * (int)m_facing;
				transform.localScale = scale;
			}
		}

		public virtual void Damaged(int damage)
		{
			Die ();
		}

		public virtual void Die()
		{
			
		}
	}
}
