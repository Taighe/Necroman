using UnityEngine;
using System.Collections;
using nENTITY;

namespace nREMNANT
{
	public class Remnant : Entity 
	{ 
		BoxCollider2D m_collider;

		void OnTriggerStay2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Gravity") 
			{
				m_rigid2D.isKinematic = false;
			}
		}

		// Use this for initialization
		void Start () 
		{
			m_collider = GetComponent<BoxCollider2D> ();
		}

		public override void Die()
		{
			Destroy (this.gameObject);
		}
	}
}
