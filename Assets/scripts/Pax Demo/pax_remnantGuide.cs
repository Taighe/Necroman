﻿using UnityEngine;
using System.Collections;
using nDATACONTROL;

public class pax_remnantGuide : MonoBehaviour 
{
	public GameObject m_remnant;

	void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Soul" && m_remnant == null)
        {
            collider.gameObject.GetComponent<SoulParticle>().SetTarget(transform.GetChild(0).gameObject, Vector2.zero);
        }

        if (collider.gameObject.tag == "Remnant")
        {
            m_remnant = collider.gameObject;
        }
    }
    
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Remnant") 
		{
			m_remnant = null;
		}
	}
}