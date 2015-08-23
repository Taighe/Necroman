using UnityEngine;
using System.Collections;
using nREMNANT;
using nENTITY;
using nATTACK;
using nSCENE;

public class Player : Entity 
{
	//prefabs
	public GameObject p_remnant;
	public GameObject p_attack;
	public GameObject p_deathEffect;
	//

	public float speed;
	public float minJump;
	public float maxJump;
	
	public float recoverTime;

	float jumpForce;

	public int maxRemnants;

	Vector2 checkPoint;

	bool JUMPKEYRELEASED = false;
	bool JUMPINITIATED = false;
	bool JUMPAPEX = false;
	
	float m_time;
	float m_deathTimer;

	Vector2 m_velocity;
	
	ArrayList m_remnants;
	
	GameObject m_attack;
	
	//Collisions
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Check Point") 
		{
			checkPoint = new Vector2(collision.transform.position.x, collision.transform.position.y);
			if(collision.gameObject.name == "Interactable" && Input.GetButtonDown("Interact"))
			{
				collision.gameObject.transform.parent = transform;
			}
		}
	}

	void Start()
	{
		m_remnants = new ArrayList ();
		
		m_attack = null;
		checkPoint = new Vector2(transform.position.x, transform.position.y);
		SetState (State.ALIVE, ref m_state);
	}

	// Update is called once per frame
	void Update () 
	{
		//If game is paused don't update object
		if (IsPaused() )
			return;

		//State machine
		switch (m_state) 
		{
			case State.ALIVE:
			{
				m_velocity.x = m_rigid2D.velocity.x;
				m_velocity.y = m_rigid2D.velocity.y;
				
				Controls ();//Inputs linked to player actions
				
				m_rigid2D.velocity = m_velocity; 
				break;
			}
			case State.DEATH:
			{
				Vector2 _pos = new Vector2(transform.position.x, transform.position.y);	
				
				if(Time.time >= m_deathTimer)
				{
					if(GetComponent<Translation>().Translate() >= 1)
					{
						GetComponent<Translation>().m_timer = 0;
						SetState(State.ALIVE, ref m_state);
					}
				}	

				break;
			}
		}
	}

	void Jump()
	{
		JUMPINITIATED = true;
		JUMPKEYRELEASED = false;
		m_time = 0;
	}

	void TimedJump()
	{
		if (m_time >= 1.0f) 
		{
			JUMPAPEX = true;
			return;
		}

		m_time += 10.0f * Time.deltaTime;

		m_time = Mathf.Clamp (m_time, 0, 1.0f);

		jumpForce = minJump + m_time * (maxJump - minJump);
		m_velocity.y = jumpForce;
	}
	
	void Controls()
	{
		if(Input.GetButtonDown("Interact"))
		{
			if(IsINTERACTABLE == true)
			{
				pickUp = interactable;
				interactable.transform.parent = transform;
			}
		}

		if(Input.GetButtonDown("Attack"))
		{
			if(pickUp == null)
			{
				Attack ();
			}
			else
			{
				pickUp = null;
				Throw ();
			}
		}

		if(Input.GetButtonDown("Reset"))
		{
			for(int i = 0; i < m_remnants.Count; i++)
			{
				Destroy( (GameObject)m_remnants[i]);
			}

			GameScene.AddLevelTime(-100);
		}

		//Jumping
		if (Input.GetButton ("Jump") && IsOnGround() )
		{
			Jump ();
		}

		if (Input.GetButton ("Jump") == true && JUMPINITIATED == true && JUMPKEYRELEASED == false)
		{
			TimedJump ();	
		}

		if (Input.GetButton ("Jump") == false && JUMPINITIATED == true) 
		{
			JUMPKEYRELEASED = true;
			JUMPINITIATED = false;
		}

		//Movement
		m_velocity.x = Input.GetAxis ("Horizontal") * speed;

		if(Input.GetAxis ("Horizontal") < 0) m_facing = Facing.LEFT;
		if(Input.GetAxis ("Horizontal") > 0) m_facing = Facing.RIGHT;

	}

	void ResetRemenants()
	{

	}

	bool IsAttacking()
	{
		if (m_attack != null) 
		{
			return true;
		} 
		else 
		{
			return false;
		}

	}

	void Throw()
	{
		interactable.transform.parent = null;
		Vector2 _force = new Vector2 (2 * (float)m_facing, 5.0f);
		interactable.GetComponent<Rigidbody2D> ().velocity = _force;
		interactable = null;
	}

	void Attack()
	{
		float offsetX = 2;

		float offsetY = 2 * Input.GetAxis("Vertical");

		if (IsAttacking () == false) 
		{
			GameObject _obj = (GameObject)Instantiate (p_attack, transform.position, transform.rotation); //Instatiate AttackBox Object
			_obj.transform.SetParent(transform);
			_obj.GetComponent<AttackBox> ().SetAttack (0.5f, 1.0f, 1, Team.PLAYER);

			Vector3 _pos = new Vector3(transform.position.x + (offsetX * (float)m_facing), transform.position.y + offsetY, transform.position.z);
			_obj.transform.position = _pos;

			m_attack = _obj;
		}
	}

	public override void Damaged(int damage)
	{
		Die ();
	}

	public override void Die()
	{
		SetState (State.DEATH, ref m_state);
		m_deathTimer = Time.time + recoverTime;

		for(int i = 0; i < m_remnants.Count; i++)
		{
			if(m_remnants[i] == null)m_remnants.RemoveAt(i);
		}
	
		if(m_remnants.Count >= maxRemnants)
		{
			Destroy((GameObject)m_remnants[0]);
			m_remnants.RemoveAt(0);
		}

		GameObject _obj = (GameObject)Instantiate(p_remnant, transform.position, transform.rotation);
		m_remnants.Add (_obj.gameObject);

		Vector3 _pos = new Vector3(checkPoint.x, checkPoint.y, 0);

		GetComponent<Translation> ().SetTranslate (transform.position, _pos);

	}

	bool SetState(State state, ref State address)
	{
		ParticleSystem _particle = GetComponentInChildren<ParticleSystem>();
		BoxCollider2D _box = GetComponent<BoxCollider2D>();
		SpriteRenderer _sprite = GetComponent<SpriteRenderer> ();

		switch (state) 
		{
			case State.ALIVE:
			{
				_sprite.enabled = true;
				_particle.emissionRate = 0;
				_box.enabled = true;
				m_rigid2D.isKinematic = false;
				address = state;
				return true; 
			}
			case State.DEATH:
			{
				_sprite.enabled = false;
				_particle.emissionRate = 15;
				_box.enabled = false;
				m_rigid2D.isKinematic = true;
				address = state;
				return true; 
			}
		}

		return false;
	}
	

}
