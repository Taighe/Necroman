using UnityEngine;
using System.Collections;
using nENTITY;

public class Spikes : MonoBehaviour 
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
            if(collision.contacts[0].normal.y < 0 )
            {
                collision.gameObject.GetComponent<Entity>().Damaged(damage);
            }
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
