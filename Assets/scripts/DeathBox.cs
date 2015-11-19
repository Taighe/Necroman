using UnityEngine;
using System.Collections;
using nENTITY;

public class DeathBox : MonoBehaviour 
{
    public int damage = 1;

<<<<<<< HEAD
    void OnTriggerEnter2D(Collider2D collision)
=======
    void OnCollisionEnter2D(Collision2D collision)
>>>>>>> 21dc313385a69ec8ab09a283464716e27b7ab483
	{
		if (collision.gameObject.tag == "Player" && collision.GetComponent<Player>().m_state == State.ALIVE) 
		{
            collision.gameObject.GetComponent<Entity>().Damaged(damage);
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
