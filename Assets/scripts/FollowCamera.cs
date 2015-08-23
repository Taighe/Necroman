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
		public GameObject cameraBounds;
		public int layerZ;

		Vector3 point1;
		Vector3 point2;

		float startTime;
		float endTime;

		// Use this for initialization
		void Start () 
		{
			if(followObject == null) return;

			point1 = transform.position;
			point2 = followObject.transform.position;
		}
		
		// Update is called once per frame
		void Update () 
		{
			Vector3 oldPos = transform.position;
			float distCovered = (Time.smoothDeltaTime * followSpeed);

			Vector2 _pos = Vector2.Lerp(point1, point2, distCovered );

			transform.position = _pos;

			Translate (transform.position, followObject.transform.position);

			StayWithBounds (ref _pos, ref oldPos);

			transform.position = new Vector3(_pos.x, _pos.y, layerZ);

		}

		bool StayWithBounds(ref Vector2 currentPosition, ref Vector3 oldPosition)
		{
			if (cameraBounds != null) 
			{
				Rect _bounds = GetComponent<Camera>().pixelRect;
				Rect worldBounds = cameraBounds.GetComponent<CameraBounds> ().bounds;
				
				Vector2 camWorldMin = GetComponent<Camera> ().ScreenToWorldPoint (_bounds.min);
				Vector2 camWorldMax = GetComponent<Camera> ().ScreenToWorldPoint (_bounds.max);
				
				//Check if the camera is outside the worlds camera bounds
				if ( !(camWorldMin.x > worldBounds.min.x && camWorldMax.x < worldBounds.max.x))
				{
					currentPosition.x = oldPosition.x;
					
				} 
				
				if( !(camWorldMin.y > worldBounds.min.y && camWorldMax.y < worldBounds.max.y))
				{
					currentPosition.y = oldPosition.y;
				}

				return true;
			}

			return false;
		}

		public void Translate (Vector3 origin, Vector3 dest)
		{		
			point1 = origin;

			dest = new Vector3 (dest.x + offsetX * (float)followObject.GetComponent<Entity> ().m_facing, dest.y, dest.z);
			point2 = dest;

		}
	}
}