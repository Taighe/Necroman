using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

namespace nREMNANT
{

	public class Remnant : Entity 
	{ 
		public Object soulParticle;
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
			GameObject soul = (GameObject)Instantiate (soulParticle, transform.position, transform.rotation);
			soul.GetComponent<SoulParticle> ().SetTarget (GameScene.gameScene.player);
			Destroy (gameObject);
		}
	}
}
