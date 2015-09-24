using UnityEngine;
using System.Collections;
using nENTITY;

namespace nFOLLOWCAMERA
{
	public class FollowCamera : MonoBehaviour 
	{
		public static FollowCamera control;

		public GameObject followObject;

		public float followSpeed = 1.0f;
		public float offsetX = 0.0f;
		public float offsetY = 0.0f;
		public GameObject cameraBounds;
		public int layerZ;

		public float followRange;

		Vector2 followRangeMin;
		Vector2 followRangeMid;
		Vector2 followRangeMax;

		Vector3 point1;
		Vector3 point2;

		float startTime;
		float endTime;

		void OnDrawGizmos()
		{
			Debug.DrawLine (followRangeMin, followRangeMax);
		}

		void Awake()
		{
			if (control == null)
				control = this;
		}

		// Use this for initialization
		void Start () 
		{
			if(followObject == null) return;

			startTime = Time.time;

			followRangeMin.x = followObject.transform.position.x - followRange;
			followRangeMid.x = followObject.transform.position.x;
			followRangeMax.x = followObject.transform.position.x + followRange;
			point1 = transform.position;
			point2 = followObject.transform.position;
		}
		
		// Update is called once per frame
		void Update () 
		{
			Vector3 oldPos = transform.position;

			float distCovered = Time.deltaTime * followSpeed;

			Vector2 _pos = Vector2.Lerp(point1, point2, distCovered );

			Vector2 _dest = point2;

			//tether
			if(followObject.transform.position.x > followRangeMax.x)
			{
				followRangeMax.x = followObject.transform.position.x;
				followRangeMin.x = followRangeMax.x - followRange * 2;
				_dest.x = followObject.transform.position.x + offsetX;
			}

			if(followObject.transform.position.x < followRangeMin.x)
			{
				followRangeMin.x = followObject.transform.position.x;
				followRangeMax.x = followRangeMin.x + followRange * 2;
				_dest.x = followObject.transform.position.x - offsetX;
			}

			_dest.y = followObject.transform.position.y + offsetY;

			Translate (_pos, _dest);

			transform.position = new Vector3(_pos.x, _pos.y, layerZ);

			StayWithBounds (ref _pos, oldPos);
		}

		bool StayWithBounds(ref Vector2 currentPosition, Vector3 oldPosition)
		{
			if (cameraBounds != null)
			{
				Rect _bounds = GetComponent<Camera>().pixelRect;
				Rect worldBounds = cameraBounds.GetComponent<CameraBounds> ().bounds;
				
				Vector2 camWorldMin = GetComponent<Camera> ().ScreenToWorldPoint (_bounds.min);
				Vector2 camWorldMax = GetComponent<Camera> ().ScreenToWorldPoint (_bounds.max);
				
				//Check if the camera is outside the worlds camera bounds
				if ( !(camWorldMin.x >= worldBounds.min.x && camWorldMax.x <= worldBounds.max.x))
				{
					currentPosition.x = oldPosition.x;
				} 
				
				if( !(camWorldMin.y >= worldBounds.min.y && camWorldMax.y <= worldBounds.max.y))
				{
					currentPosition.y = oldPosition.y;
				}

				transform.position = new Vector3(currentPosition.x, currentPosition.y, layerZ);

				return true;
			}

			return false;
		}

		public void Translate (Vector3 origin, Vector3 dest)
		{		
			point1 = origin;
			point2 = dest;
			startTime = Time.time;
		}
	}
}