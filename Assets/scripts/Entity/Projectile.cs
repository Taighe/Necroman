using UnityEngine;
using System.Collections;
using nENTITY;

public class Projectile : Entity 
{
	float m_speed;
	GameObject m_owner;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			collision.gameObject.GetComponent<Entity>().Die ();
			Destroy(this.gameObject);
		}

		if(collision.gameObject.tag == "Terrain")
		{
			GameObject _obj = collision.gameObject;

			Destroy(this.gameObject);

		}
	}

	public void SetProjectile(float speed, int facing, GameObject owner)
	{
		m_facing = (Facing)facing;
		m_speed = speed;
		m_owner = owner;
		ChangeInFacing ();

	} 

	// Update is called once per frame
	void Update () 
	{
		//If game is paused don't update object
		if (IsPaused() )
			return;

		Vector3 _pos = transform.position;
		_pos.x += (m_speed * (float)m_facing) * Time.deltaTime;

		transform.position = _pos;
	}

	public override void Die()
	{

	}
}
