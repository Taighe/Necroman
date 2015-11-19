using UnityEngine;
using System.Collections;
using nENTITY;

public class FallingPlatform : Entity 
{
    public float time;
    public float delay;
    public float fallSpeed;
    public float dampen;
    public float respawnDelay;

    Vector2 m_origin;
    bool m_fall;

	// Use this for initialization
	void Start () 
    {
        m_origin = transform.position;
        m_fall = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.contacts[0].normal.y < 0)
            {
                m_fall = true;
            }
        }
    }

	// Update is called once per frame
	new void Update () 
    { 
        if(m_fall)
        {
            time += 1.0f * Time.deltaTime;
            if(time >= delay)
            {
                m_velocity.y += fallSpeed;
                //GetComponent<Entity>().Update();
                if (m_velocity.y <= maxFallSpeed) m_velocity.y = maxFallSpeed;

                transform.position -= (new Vector3(m_velocity.x, m_velocity.y, 0) * dampen) * Time.deltaTime;
            }

            if (time >= respawnDelay) Reset();
        }

	}

    void Reset()
    {
        m_fall = false;
        transform.position = m_origin;
        m_velocity = Vector2.zero;
        time = 0;
    }
}
