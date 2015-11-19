using UnityEngine;
using System.Collections;
using nENTITY;
using nSCENE;

public class Controllable : Entity 
{
    public bool active;
    public float speed;
    public float maxSpeed;

    public GameObject p_soul;
    Vector2 m_origin;

	// Use this for initialization
	void Start () 
    {
        m_origin = transform.position;
	}
	
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Soul" && active == false)
        {
            active = true;
            collision.gameObject.GetComponent<SoulParticle>().SetTarget(gameObject, Vector2.zero);
        }
    }

    // Update is called once per frame
	new void Update () 
    {
        GetComponent<Entity>().Update();

        Vector2 _velocity = GetComponent<Rigidbody2D>().velocity;

        if(_velocity.x > maxSpeed)
        {
            _velocity.x = maxSpeed;
        }

        if (_velocity.x < -maxSpeed)
        {
            _velocity.x = -maxSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = _velocity;

        if (Input.GetButtonDown("Reset") && active)
        {
            GameObject soul = (GameObject)Instantiate(p_soul, transform.position, transform.rotation);
            soul.GetComponent<SoulParticle>().SetTarget(GameScene.gameScene.player, Vector2.zero);
            soul.tag = "SoulCollect";
            active = false;
        }
	}

    void FixedUpdate()
    {
        if (active)
        {
            //Movement
            if (Input.GetAxis("Right Stick Horizontal") > 0)
            {
                m_rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            }
            else if (Input.GetAxis("Right Stick Horizontal") < 0)
            {
                m_rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            }
        }
        else
        {
            
        }
    }
}
