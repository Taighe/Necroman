using UnityEngine;
using System.Collections;
using nENTITY;
using nATTACK;

public class Bomb : Entity 
{
	public bool activated;
	public float fuseTime;
	public GameObject attack;
	
	float m_timer;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.parent == null) 
		{
			m_rigid2D.isKinematic = false;
		}
		else
		{
			float height = transform.parent.transform.gameObject.GetComponent<BoxCollider2D>().size.y;
			transform.position = transform.parent.transform.position;
			Vector3 _pos = transform.position;

			_pos.y += height + 1.0f;
			transform.position = _pos;
			m_rigid2D.isKinematic = true;
		}

		if(activated == true)
		{
			m_timer += 1.00f * Time.deltaTime;
				
			if(m_timer > fuseTime)
			{
				Die ();
			}
		}

	}

	public override void Damaged(int damage)
	{
		activated = true;
	}

	public override void Die()
	{
		GameObject _obj = (GameObject)Instantiate (attack, transform.position, transform.rotation );
		_obj.GetComponent<AttackBox> ().SetAttack (0, 2, 1, m_team);
		_obj.transform.localScale = new Vector3 (2, 2, 1);
		Destroy (this.gameObject);
	}
}
