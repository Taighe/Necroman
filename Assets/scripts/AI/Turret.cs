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

	Light m_light;

	// Use this for initialization
	void Start () 
	{
		m_light = transform.GetChild (0).gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused == true)
			return;

		m_timer += 1.0f * Time.deltaTime;

		if(CanFire() )
		{
			Vector2 _pos = transform.position;
            _pos.x = _pos.x + (0.8f * (float)m_facing);
            GameObject _obj = (GameObject)Instantiate(projectile, _pos, transform.rotation);
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
