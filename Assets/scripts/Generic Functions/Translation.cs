using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour
{
	public float speed = 1.0f;
	public Vector3 point1;
	public Vector3 point2;
	public Vector2 m_velocity;
	float maxSpeed = Mathf.Infinity;
    public Vector2 endRectSize;
    public bool increaseSpeed;

	public bool independent;

    public void SetTranslationValues(float a_speed, Vector2 a_velocity, float a_maxSpeed, Vector2 a_endRectSize)
    {
        speed = a_speed;
        m_velocity = a_velocity;
        maxSpeed = a_maxSpeed;
        endRectSize = a_endRectSize;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(independent == true)
		{
			Translate();
		}
	}

	public void Translate()
	{
        if (increaseSpeed) speed -= 1.0f * Time.deltaTime;
        
        Vector2 _pos = transform.position;
		_pos = Vector2.SmoothDamp (_pos, point2, ref m_velocity, speed, maxSpeed);

		transform.position = new Vector3(_pos.x, _pos.y, 0);

	}

	public bool AtDestination()
	{
        Rect _rect = new Rect(point2, new Vector2(endRectSize.x, endRectSize.y));
		_rect.center = point2;
		Vector2 _pos = transform.position;

		return _rect.Contains (_pos, true);
	}

    public bool AtOrigin()
    {
        Rect _rect = new Rect(point2, new Vector2(endRectSize.x, endRectSize.y));
        _rect.center = point1;
        Vector2 _pos = transform.position;

        return _rect.Contains(_pos, true);
    }

	public void SetTranslate (Vector3 origin, Vector3 dest)
	{		
		point1 = origin;
		point2 = dest;
	}
}