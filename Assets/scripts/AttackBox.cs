﻿using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

namespace nATTACK
{
	public class AttackBox : MonoBehaviour 
	{
		float m_timer;

		float m_attackFrame;

		float m_attackLength;

		int m_damage;

		Team m_team;

		GameObject m_owner;

		// Use this for initialization
		void Start () 
		{
		
		}

		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Remnant") 
			{
				GameObject _obj = collision.gameObject;
				if(_obj.GetComponent<Entity>().m_team != m_team)
				{
					Destroy(_obj);
					Destroy(this.gameObject);
				}

			}

			if (collision.gameObject.tag != "Terrain") 
			{
				GameObject _obj = collision.gameObject;
				GameObject _owner = m_owner;

				if(_obj.GetComponent<Entity>().m_team != m_team)
				{
					float degrees;
					Vector3 _axis = Vector3.zero;
					transform.rotation.ToAngleAxis(out degrees, out _axis);

					if(_axis.z < 0)
					{
						m_owner.GetComponent<Player>().Hop ();
					}

					_obj.GetComponent<Entity>().Damaged(m_damage);
					Destroy(this.gameObject);
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
			m_attackLength = attackLength + Time.time;
			m_damage = damage;
			m_team = owner;
		}

		public void SetAttack(float attackFrame, float attackLength, int damage, Team owner, GameObject origin )
		{
			m_timer = Time.time;
			m_attackFrame = attackFrame;
			m_attackLength = attackLength + Time.time;
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