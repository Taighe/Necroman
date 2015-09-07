using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

public class Turret : Entity 
{
	public GameObject projectile;
	public float delay;
	public float speed;

	public float m_timer;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused == true)
			return;

		m_timer += 1.0f * Time.deltaTime;

		if(CanFire() )
		{
			GameObject _obj = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			_obj.GetComponent<Projectile>().SetProjectile(speed, (int)m_facing, this.gameObject);
		}
	}

	bool CanFire()
	{
		if (projectile == null)
			return false;

		if(m_timer > delay)
		{
			m_timer = 0;
			return true;
		}

		return false;
	}
}
