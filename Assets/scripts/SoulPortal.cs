using UnityEngine;
using System.Collections;
using nSCENE;

public class SoulPortal : MonoBehaviour 
{
    public bool m_active;
    public Vector2 force;

	// Use this for initialization
	void Start () 
    {
	
	}

    void Update()
    {
        if (m_active) GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        else GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

        if (GameScene.gameScene.player.GetComponent<Player>().m_portalCheckPoint == this.gameObject)
        {
            m_active = true;
        }
        else m_active = false;

    }

    public void RememberForce(Vector2 velocity)
    {
        if (m_active == false)
        {
            force = velocity;
        }
    }

}
