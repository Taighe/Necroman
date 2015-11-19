using UnityEngine;
using System.Collections;
using nENTITY;

public class DeathBox : MonoBehaviour 
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D collision)
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
