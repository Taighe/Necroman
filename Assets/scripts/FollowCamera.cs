using UnityEngine;
using System.Collections;
using nENTITY;

namespace nFOLLOWCAMERA
{
	public class FollowCamera : MonoBehaviour 
	{
		public GameObject followObject;

		public float followSpeed = 1.0f;
		public float offsetX = 0.0f;

		bool SMOOTHFOLLOW = false;

		Vector3 point1;
		Vector3 point2;

		float startTime;
		float endTime;

		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			float distCovered = (Time.smoothDeltaTime * followSpeed);

			Vector2 _pos = Vector2.Lerp(point1, point2, distCovered );
			transform.position = new Vector3(_pos.x, _pos.y, -1.0f);

			Translate (transform.position, followObject.transform.position);

		}

		public void Translate (Vector3 origin, Vector3 dest)
		{		
			point1 = origin;

			dest = new Vector3 (dest.x + offsetX * (float)followObject.GetComponent<Entity> ().m_facing, dest.y, dest.z);
			point2 = dest;

		}
	}
}