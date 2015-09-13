using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour 
{
	public float speed = 1.0f;
	public Vector3 point1;
	public Vector3 point2;
	public float m_timer;
	
	// Use this for initialization
	void Start () 
	{
		m_timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public float Translate()
	{
		m_timer += speed * Time.smoothDeltaTime;
		
		Vector2 _pos = Vector2.Lerp(point1, point2, m_timer );
		transform.position = new Vector3(_pos.x, _pos.y, 0);

		return m_timer;
	}

	public void SetTranslate (Vector3 origin, Vector3 dest)
	{		
		point1 = origin;
		point2 = dest;
	}
}