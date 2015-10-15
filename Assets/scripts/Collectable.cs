using UnityEngine;
using System.Collections;
using nSCENE;
using nLEVELDATA;

namespace nCOLLECTABLE
{
	public enum Type
	{
		SOUL_FRAGMENT,
		SOUL_SHARD,
	}

	public class Collectable : MonoBehaviour 
	{
		public bool IsCollected;
		public AudioSource source;
		public AudioClip sfxCollect;
		public Type m_type;

		void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Player" && IsCollected == false)
			{
				IsCollected = true;
				GameScene.gameScene.currentSoulFragments += 1;
				source.PlayOneShot(sfxCollect);
			}
		}

		// Use this for initialization
		void Start () 
		{

		}
		
		// Update is called once per frame
		void Update () 
		{
			if(IsCollected && m_type == Type.SOUL_FRAGMENT)
			{
				transform.GetChild(0).gameObject.SetActive(false);
				BoxCollider2D _box = GetComponent <BoxCollider2D>();

				//transform.GetChild(0).GetComponent<Animator>().SetBool("Collected", true);
				_box.enabled = false;
			}
		}
	}
}
