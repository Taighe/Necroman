using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public float speed;

	void Update() {
		transform.Rotate(Vector3.down * speed);
		transform.Rotate(Vector3.up * 0, Space.World);
	}
}