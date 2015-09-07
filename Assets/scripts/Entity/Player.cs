using UnityEngine;
using System.Collections;
using nREMNANT;
using nENTITY;
using nATTACK;
using nSCENE;
using nFOLLOWCAMERA;

public enum AnimationState
{
	PRE_INTRO = -2,
	INTRO,
	IDLE,
	RUN,
	JUMP,
	FALL,
	ATTACK,
	ATTACK_UP,
	ATTACK_DOWN
}

public class Player : Entity 
{
	//prefabs
	public GameObject p_remnant;
	public GameObject p_attack;
	public GameObject p_deathEffect;
	public bool disableControl;

	public int maxRemnants;
	public int startAnim;
	public float speed;
	public float minJump;
	public float maxJump;
	public float remnantSpawnOffsetY;
	
	public float recoverTime;
	public float boostJump;
	public float peekOffsetY;

	public int m_remnantCount;

	GameObject interactable;
	GameObject pickUp;

	Rect m_respawnArea;

	float jumpForce;

	Vector2 checkPoint;

	bool JUMPKEYRELEASED = false;
	bool JUMPINITIATED = false;
	bool JUMPAPEX = false;
	
	float m_time;
	float m_deathTimer;

	AnimationState m_animState;
	Animator m_animator;

	ArrayList m_remnants;
	
	GameObject m_attack;

	//Collisions
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Check Point") 
		{
			checkPoint = new Vector2(collision.transform.position.x, collision.transform.position.y);
		}

	}

	void OnCollisionStay2D(Collision2D collision)
	{
		Entity _entity = GetComponent<Entity> ();
		_entity.OnCollisionStay2D (collision);
		
		if(collision.gameObject.tag == "Interactable")
		{
			interactable = collision.gameObject;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		Entity _entity = GetComponent<Entity> ();
		_entity.OnCollisionExit2D (collision);
		
		if(collision.gameObject.tag == "Interactable")
		{
			interactable = null;
		}

	}

	void Start()
	{
		m_animator = GetComponent<Animator> ();

		m_animator.SetInteger ("State", startAnim);

		m_respawnArea = new Rect (transform.position, new Vector2(3.0f, 3.0f) );
		m_remnants = new ArrayList ();
		m_animState = AnimationState.IDLE;
		m_attack = null;
		checkPoint = new Vector2(transform.position.x, transform.position.y);
		SetState (State.ALIVE, ref m_state);
	}

	// Update is called once per frame
	void Update() 
	{
		Entity _entity = GetComponent<Entity> ();
		_entity.Update ();

		m_remnantCount = m_remnants.Count;

		//If game is paused don't update object
		if (IsPaused() )
			return;

		//State machine
		switch (m_state) 
		{
			case State.ALIVE:
			{
				if(disableControl == false) 
				{
					Controls ();
					AnimationControl();
				}
				
				ChangeInFacing();

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
		if (Input.GetButtonDown ("Submit") && Scene.buttonPressed == false) 
		{
			Scene.paused = true;
			return;
		}

		Scene.buttonPressed = false;

		if(Input.GetButton("Interact"))
		{
			if(pickUp == null)
			{
				pickUp = interactable;
				pickUp.transform.parent = transform;
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
				Throw ();
			}
		}

		if(Input.GetButtonDown("Reset"))
		{
			ResetRemenants();
		}

		//Jump
		bool _ground = IsOnGround ();

		if (Input.GetButtonDown ("Jump") && _ground && !(Input.GetAxis ("Vertical") < 0))
		{
			Jump ();
		}
		else if (Input.GetButton ("Jump") && _ground && Input.GetAxis ("Vertical") < 0 && m_collision.gameObject.tag == "Remnant")//Drop
		{
			Drop ();
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

		//Camera actions
		if(IsOnGround() ) FollowCamera.control.offsetY = Input.GetAxis ("Vertical") * peekOffsetY;

	}

	public void Hop(float boost)
	{
		m_velocity.y = boost;
		m_rigid2D.velocity = m_velocity;
	}
	
	void ResetRemenants()
	{
		for(int i = 0; i < m_remnants.Count; i++)
		{
			Destroy( (GameObject)m_remnants[i] );
		}

		m_remnants.Clear ();
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
		Vector2 _force = new Vector2 (m_velocity.x + (5.0f * (float)m_facing) , 5.0f);
		pickUp.GetComponent<Rigidbody2D> ().velocity = _force;
		pickUp.transform.parent = null;
		pickUp = null;
	}

	void Attack()
	{
		float offsetX = 1;
		float offsetY = 0;

		if(Input.GetAxis("Vertical") < 0)
		{
			offsetY = -1;
			offsetX = 0;
		}
		else if(Input.GetAxis("Vertical") > 0)
		{
			offsetY = 1;
			offsetX = 0;
		}

		if (IsAttacking () == false) 
		{
			GameObject _obj = (GameObject)Instantiate (p_attack, transform.position, new Quaternion(0, 0, offsetY, 1) ); //Instatiate AttackBox Object
			_obj.transform.SetParent(transform);
			_obj.GetComponent<AttackBox> ().SetAttack (0.5f, 1.0f, 1, Team.PLAYER, this.gameObject);

			Vector3 _pos = new Vector3(transform.position.x + (offsetX * (float)m_facing), transform.position.y + offsetY, transform.position.z);
			_obj.transform.position = _pos;

			m_attack = _obj;
		}
	}

	void Drop()
	{
		if(m_collision.gameObject.tag == "Remnant")
		{
			BoxCollider2D _collider = m_collision.gameObject.GetComponent<BoxCollider2D>();
			_collider.enabled = false;
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
			if(m_remnants[i] == null)
			{
				m_remnants.RemoveAt(i);
			}
		}

		Vector3 remPos = transform.position;
		remPos.y += remnantSpawnOffsetY;

		if(m_collision.gameObject.tag != "Cursed" && m_remnants.Count < maxRemnants)
		{
			GameObject _obj = (GameObject)Instantiate(p_remnant, remPos, transform.rotation);
			m_remnants.Add (_obj.gameObject);
		}

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
				if(pickUp != null)
				{
					pickUp.transform.parent = null;
					pickUp = null;
				}
				
				if(m_attack != null) Destroy(m_attack.gameObject);
				
				_particle.emissionRate = 15;
				_box.enabled = false;
				Vector2 vel = Vector2.zero;
				m_rigid2D.velocity = vel;
				m_rigid2D.isKinematic = true;
				address = state;
				return true; 
			}
		}

		return false;
	}

	public void Intro()
	{
		Hop(15);
	}

	void AnimationControl()
	{
		if (IsOnGround ())
		{
			m_animState = AnimationState.IDLE;
			m_animator.speed = 1.0f;
		}

		if (m_velocity.x != 0 && IsOnGround()) 
		{
			m_animState = AnimationState.RUN;
		}


		m_animator.SetInteger ("State", (int)m_animState);
	}

	public bool RespawnSignal()
	{
		if (Input.GetButtonDown ("Reset")) 
		{
			return true;
		} 

		return false;
	}

	public void ResizeRemnantArray()
	{
		for(int i = 0; i < m_remnants.Count; i++)
		{
			GameObject _obj = (GameObject)m_remnants[i];

			if(_obj.GetComponent<Entity>().IsDestroyed)
			m_remnants.RemoveAt(i);

		}
	}
}
