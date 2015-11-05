using UnityEngine;
using System.Collections;
using nENTITY;

public class DeathBox : MonoBehaviour 
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
            collision.gameObject.GetComponent<Entity>().Damaged(damage);
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
