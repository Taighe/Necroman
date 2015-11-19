using UnityEngine;
using System.Collections;

public class Permanent : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject);

        GameObject m_object = GameObject.Find(gameObject.name);
        if(m_object != gameObject)
        {
            Destroy(gameObject);
        } 
	}

}
