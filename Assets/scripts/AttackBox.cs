using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

namespace nATTACK
{
	public class AttackBox : MonoBehaviour 
	{
		public float m_timer;

		public float m_attackFrame;

		public float m_attackLength;

		int m_damage;

		Team m_team;

		GameObject m_owner;
		public GameObject explosion;

		void Start()
		{
			m_timer = 0;
		}

		void OnTriggerStay2D(Collider2D collision)
		{
			if (m_timer < m_attackFrame)
				return;

			if (collision.gameObject.tag != "Terrain") 
			{
				Entity _entity = collision.gameObject.GetComponent<Entity>();
				if(_entity == null) return;

				GameObject _owner = m_owner;

				Player _player = m_owner.GetComponent<Player>();

				if(_entity.m_team != m_team)
				{
					float degrees;
					Vector3 _axis = Vector3.zero;
					transform.rotation.ToAngleAxis(out degrees, out _axis);

					if(_axis.z < 0 && _player != null)
					{
						float boost = _player.boostJump;

						_player.Hop (boost);
					}

					_entity.GetComponent<Entity>().Damaged(m_damage);
					Instantiate(explosion, transform.position, transform.rotation);
					Destroy(gameObject);
				}
			}

		}

		/// Initialize Attack box properties:
		/// 
		/// attackFrame - sets the time when this box will enable to hurt other characters
		/// 
		/// attackLength - sets how long the attack box will last. (-1 for infinite)
		/// 
		/// damage
		/// owner - is what team generated the attack
		public void SetAttack(float attackFrame, float attackLength, int damage, Team owner )
		{
			m_timer = Time.time;
			m_attackFrame = attackFrame;
			m_attackLength = attackLength;
			m_damage = damage;
			m_team = owner;
		}

		public void SetAttack(float attackFrame, float attackLength, int damage, Team owner, GameObject origin )
		{
			m_timer = Time.time;
			m_attackFrame = attackFrame;
			m_attackLength = attackLength;
			m_damage = damage;
			m_team = owner;
			m_owner = origin;
		}

		// Update is called once per frame
		void Update () 
		{
			if (Scene.paused)
				return;

			m_timer += 1.0f * Time.deltaTime;

			if(m_timer >= m_attackLength && m_attackLength != -1)
			{
				Destroy(this.gameObject);
			}
		}
	}
}