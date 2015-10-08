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
	INTRO = -1,
	IDLE = 0,
	RUN = 1,
	JUMP = 2,
	FALL = 3,
	ATTACK = 4,
	ATTACK_UP = 5,
	ATTACK_DOWN = 6,
	LAND = 7,
	LOOK_UP = 8,
	LOOK_DOWN = 9,
	EXIT = 10
}

public class Player : Entity 
{
	//prefabs
	public GameObject p_remnant;
	public GameObject p_attack;
	public GameObject p_deathEffect;
	public Object p_soul;
	public bool disableControl;
	public GameObject deathExplosion;

	public int maxRemnants;
	public int startAnim;
	public float speed;
	public float minJump;
	public float maxJump;
	public float remnantSpawnOffsetY;
	
	public float recoverTime;
	public float boostJump;
	public float peekOffsetY;
	public float peekDelay;
	public float peekTimer;

	public int m_remnantCount;

	public Rect m_respawnArea;

	public int m_lives;

	GameObject interactable;
	GameObject pickUp;

	float jumpForce;

	GameObject m_remnantGuide;

	Vector2 m_lastCheckPoint;
	Vector2 m_checkPoint;

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
		if (collision.gameObject.tag == "Checkpoint") 
		{
			m_lastCheckPoint = new Vector2(collision.transform.position.x, collision.transform.position.y);
			GameScene.gameScene.currentCheckpoint = collision.gameObject;
			GameScene.gameScene.currentCheckpoint.GetComponent<CheckPoint>().Activate();
		}

		if (collision.gameObject.tag == "Remnant Guide") 
		{
			m_remnantGuide = collision.gameObject;
		}

	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Checkpoint") 
		{
			m_lastCheckPoint = new Vector2(collision.transform.position.x, collision.transform.position.y);
		}
		
		if (collision.gameObject.tag == "Remnant Guide") 
		{
			m_remnantGuide = null;
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
		m_lives = maxRemnants;
		m_animator.SetInteger ("State", startAnim);
		m_respawnArea = new Rect (transform.position, new Vector2(15.0f, 15.0f) );
		m_remnants = new ArrayList ();
		m_animState = AnimationState.IDLE;
		m_attack = null;
		m_lastCheckPoint = new Vector2(transform.position.x, transform.position.y);
		SetState (State.ALIVE, ref m_state);
	}

	// Update is called once per frame
	void Update() 
	{
		GetComponent<Entity> ().Update ();

		m_remnantCount = m_remnants.Count;

		//If game is paused don't update object
		if (IsPaused() )
			return;

		//State machine
		switch (m_state) 
		{
			case State.ALIVE:
			{
				m_velocity.x = 0;
				if(disableControl == false) 
				{
					Controls ();
					AnimationControl();
				}
				
				ChangeInFacing();

				m_rigid2D.velocity = m_velocity;
				
				//Keep track of last remnant for respawn
				m_checkPoint = m_lastCheckPoint;	

				if(m_remnants.Count > 0)
				{
					//GameObject _lastRemnant = (GameObject)m_remnants[m_remnants.Count - 1];
					//m_checkPoint = new Vector2(_lastRemnant.transform.position.x, _lastRemnant.transform.position.y - remnantSpawnOffsetY * 2);
				}
				
				m_respawnArea.center = transform.position;
				
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

	int Looking()
	{
		return (int)Input.GetAxis ("Vertical");
	}

	void Controls()
	{
		if (Input.GetButtonDown ("Pause") && Scene.buttonPressed == false) 
		{
			Scene.paused = true;
			return;
		}

		Scene.buttonPressed = false;

        //if(Input.GetButton("Interact"))
        //{
        //    if(pickUp == null)
        //    {
        //        pickUp = interactable;
        //        pickUp.transform.parent = transform;
        //    }
        //}

        if (Input.GetButtonDown("Attack"))
        {
            if (pickUp == null)
            {
                Attack();
            }
            else
            {
                Throw();
            }
        }

		if(Input.GetButtonDown("Reset"))
		{
			ResetRemenants();
		}

		//Jump
		bool _ground = IsOnGround ();

		if (Input.GetButtonDown ("Jump") && _ground )
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
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_velocity.x = speed;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_velocity.x = -speed;
        }
        else if (Input.GetAxis("Horizontal") == 0)
            m_velocity.x = 0;
            
		//Camera actions
		FollowCamera _camera = FollowCamera.control;
		if (_camera != null) 
		{
			if (IsOnGround () && m_velocity.x == 0) 
			{
				if(Input.GetAxis ("Vertical") != 0)
				{
					peekTimer += 1.0f * Time.deltaTime;
				}
				else peekTimer = 0;
			} 
			else
				FollowCamera.control.offsetY = 0;


			if(peekTimer >= peekDelay)
			{
				FollowCamera.control.offsetY = Looking() * peekOffsetY;
			}

			if (IsAttacking () && IsOnGround ()) 
			{
				m_velocity.x = 0;
			}
		}

		if(Input.GetAxis ("Horizontal") < 0) m_facing = Facing.LEFT;
		if(Input.GetAxis ("Horizontal") > 0) m_facing = Facing.RIGHT;
	}
	
	void TimedJump()
	{
		if (m_time >= 1.0f) 
		{
			JUMPAPEX = true;
			return;
		}
		
		m_time += 5.0f * Time.deltaTime;
		
		m_time = Mathf.Clamp (m_time, 0, 1.0f);
		
		jumpForce = minJump + m_time * (maxJump - minJump);
		m_velocity.y = jumpForce;
	}

	public void AddRemnant(GameObject remnant)
	{
		m_remnants.Add (remnant);
	}

	public void Hop(float boost)
	{
		m_velocity.y = boost;
		m_rigid2D.velocity = m_velocity;
	}

	public void Exit()
	{
		m_animator.SetInteger ("State", (int)AnimationState.EXIT);
	}

	void ResetRemenants()
	{
		for(int i = 0; i < m_remnants.Count; i++)
		{
			GameObject _obj = (GameObject)m_remnants[i];
			_obj.GetComponent<Entity>().Die();
		}

		m_remnants.Clear ();
	}

	bool IsAttacking()
	{
		if (m_attack != null) 
		{
			return true;
		}

		return false;
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

		if (IsAttacking () == false ) 
		{
			GameObject _obj = (GameObject)Instantiate (p_attack, transform.position, new Quaternion(0, 0, offsetY, 1) );

			//Instantiate AttackBox Object
			_obj.transform.SetParent(transform);
			_obj.GetComponent<AttackBox> ().SetAttack (0, 0.55f, 1, Team.PLAYER, this.gameObject);

			Vector3 _pos = new Vector3(transform.position.x + (offsetX * (float)m_facing), transform.position.y + offsetY, transform.position.z);
			_obj.transform.position = _pos;
			Vector3 _scale = new Vector3(1, 0.9f, 1);
			
			_obj.transform.localScale = _scale;
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
		if (damage == 0) 
		{
			Die (true);
		} 
		else 
		{
			Die (false);
		}

	}

	public void Die(bool createPlatform)
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

		if(m_lives > 0)
		{
			GameObject soul = (GameObject)Instantiate(p_soul, transform.position, transform.rotation);
			soul.gameObject.tag = "SoulCollect";
			if (m_remnantGuide != null && m_remnantGuide.GetComponent<pax_remnantGuide>().m_remnant == null) 
			{
				soul.GetComponent<SoulParticle>().SetTarget(m_remnantGuide);
				soul.gameObject.tag = "Soul";
			}
		}

        m_lives -= 1;
        if(m_lives < 0)
        {
            m_lives = 0;
        }

		Vector3 _pos = new Vector3(m_checkPoint.x, m_checkPoint.y, 0);
		
		GetComponent<Translation> ().SetTranslate (transform.position, _pos);
		Instantiate (deathExplosion, transform.position, transform.rotation);
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
				_sprite.enabled = false;
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
		if(IsOnGround () && m_velocity.x == 0)
		{
			m_animState = AnimationState.IDLE;
		}

		if (m_velocity.x != 0 && IsOnGround()) 
		{
			m_animState = AnimationState.RUN;
		}

        if (Looking() < 0 && IsOnGround() && m_velocity.x == 0)
        {
            m_animState = AnimationState.LOOK_DOWN;
        }
        else if (Looking() > 0 && IsOnGround() && m_velocity.x == 0) m_animState = AnimationState.LOOK_UP;

		if(Landed ())
		{
			m_animState = AnimationState.LAND;
		}

		if (!IsOnGround() && m_velocity.y > 0) 
		{
			m_animState = AnimationState.JUMP;
		}

		if (!IsOnGround() && m_velocity.y < 0) 
		{
			m_animState = AnimationState.FALL;
		}
	
		AnimatorStateInfo _state = m_animator.GetCurrentAnimatorStateInfo (0);

        if (Input.GetButtonDown("Attack"))
        {
            m_animState = AnimationState.ATTACK;
            m_animator.SetLayerWeight(1, 1);

            if (Input.GetAxis("Vertical") < 0) m_animState = AnimationState.ATTACK_DOWN;

            if (Input.GetAxis("Vertical") > 0) m_animState = AnimationState.ATTACK_UP;
        } 
       
        if(IsAttacking() == false)
        {
            m_animator.SetLayerWeight(1, 0);
        }

		m_animator.SetInteger ("State", (int)m_animState);

	}

    public void AddSouls(int value)
    {
        if (m_lives >= maxRemnants) return;
        
        m_lives += value;
    }

	public bool RespawnSignal()
	{
		if (Input.GetButtonDown ("Reanimate")) 
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
