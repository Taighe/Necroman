using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

public class Turret : Entity 
{
	public GameObject projectile;
	public float delay;

	float m_timer;

	// Use this for initialization
	void Start () 
	{
		m_timer = Time.time + delay;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused == true)
			return;

		if(CanFire() )
		{
			GameObject _obj = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			_obj.GetComponent<Projectile>().SetProjectile(5.0f, (int)m_facing, this.gameObject);
		}
	}

	bool CanFire()
	{
		if (projectile == null)
			return false;

		if(Time.time > m_timer)
		{
			m_timer = Time.time + delay;
			return true;
		}

		return false;
	}
}
