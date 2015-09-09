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
		public State m_state;

		public Team m_team;
		public float maxFallSpeed;

		public bool IsPLATFORM;

		protected Rigidbody2D m_rigid2D;
		protected Vector2 m_collisionNormals;
		protected Vector2 m_velocity;
		protected Vector2 m_lastFrameVelocity;
		protected Collision2D m_collision;
		protected bool IsINTERACTABLE;


		Facing m_lastFacing; 

		float m_scaleX;

		bool m_IsDestroyed;

		public bool IsDestroyed
		{
			get{return m_IsDestroyed;}
			set{m_IsDestroyed = value;}
		}

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
			m_collision = collision;

			Entity _entity = collision.gameObject.GetComponent<Entity> ();
			
			Vector2 norms = collision.contacts[0].normal;

			m_collisionNormals.y = norms.y;
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

		public bool Landed()
		{
			if(m_collisionNormals.y > 0 && m_lastFrameVelocity.y < 0)
			{
				return true;
			}

			return false;
		}

		public bool IsPaused () 
		{
			if (Scene.paused == true) 
			{
				m_rigid2D.Sleep();
				return true;
			}

			m_rigid2D.WakeUp();
			return false;
		}

		public void Update()
		{
			if(m_rigid2D == null) return;

			m_lastFacing = m_facing;

			m_lastFrameVelocity = m_velocity;

			m_velocity.x = m_rigid2D.velocity.x;

			m_velocity.y = m_rigid2D.velocity.y;
			
			Vector2 vel = m_rigid2D.velocity;
			if (m_velocity.y < maxFallSpeed) 
			{
				m_velocity.y = maxFallSpeed;
			}

			m_rigid2D.velocity = m_velocity;
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
