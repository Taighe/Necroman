using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

public class Turret : Entity 
{
	public GameObject projectile;
	public float delay;
	public Camera currentCamera;

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
		Rect _cameraBounds = currentCamera.rect; 

		Rect _box = Rect.MinMaxRect(GetComponent<BoxCollider2D> ().bounds.min.x, GetComponent<BoxCollider2D> ().bounds.min.y,
		                            GetComponent<BoxCollider2D> ().bounds.max.x, GetComponent<BoxCollider2D> ().bounds.max.y);

		//if(_box.Overlaps(_cameraBounds) )
		{
			if(Time.time > m_timer)
			{
				m_timer = Time.time + delay;
				return true;
			}
		}

		return false;
	}
}
