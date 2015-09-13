using UnityEngine;
using System.Collections;
using nSCENE;
using nLEVELDATA;

namespace nCOLLECTABLE
{
	public class Collectable : MonoBehaviour 
	{
		public bool IsCollected;
		void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Player" && IsCollected == false)
			{
				IsCollected = true;
				GameScene.gameScene.currentSoulFragments += 1;
			}
		}

		// Use this for initialization
		void Start () 
		{

		}
		
		// Update is called once per frame
		void Update () 
		{
			if(IsCollected)
			{
				transform.GetChild(0).gameObject.SetActive(false);
				BoxCollider2D _box = GetComponent <BoxCollider2D>();
				_box.enabled = false;
			}
		}
	}
}
