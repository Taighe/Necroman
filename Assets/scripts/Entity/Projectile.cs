using UnityEngine;
using System.Collections;
using nENTITY;

public class Projectile : Entity 
{
	public float m_speed;
	GameObject m_owner;
    public int damage;

	void OnTriggerEnter2D(Collider2D collision)
	{
        Animator _anim = GetComponent<Animator>();
        if (collision.gameObject.tag == "Player" && !_anim.GetBool("Dead")) 
		{
			collision.gameObject.GetComponent<Entity>().Damaged(damage);
            Die();
		}

		if(collision.gameObject.tag == "Terrain")
		{
<<<<<<< HEAD
			//GameObject _obj = collision.gameObject;
=======
			GameObject _obj = collision.gameObject;
>>>>>>> 21dc313385a69ec8ab09a283464716e27b7ab483
            Die();
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
	new void Update () 
	{
		//If game is paused don't update object
		if (IsPaused() )
			return;

		Vector3 _pos = transform.position;
		_pos.x += (m_speed * (float)m_facing) * Time.deltaTime;

		transform.position = _pos;

        Animator _anim = GetComponent<Animator>();
        if(_anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(this.gameObject);
        }   
	}

	public override void Die()
	{
        GetComponent<Animator>().SetBool("Dead", true);
        m_speed = 0;
	}
}
