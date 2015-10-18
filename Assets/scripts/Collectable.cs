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
            if (collision.gameObject.tag == "Player" && IsCollected == false && m_type == Type.SOUL_FRAGMENT)
			{
				IsCollected = true;
				GameScene.gameScene.currentSoulFragments += 1;
				source.PlayOneShot(sfxCollect);
                transform.GetChild(0).GetComponent<Animator>().SetBool("Collect", true);
			}

            if (collision.gameObject.tag == "Player" && IsCollected == false && m_type == Type.SOUL_SHARD)
            {
                IsCollected = true;
                GameScene.gameScene.score += 10;
                transform.GetChild(0).GetComponent<Animator>().SetBool("Collect", true);
            }
		}

		// Use this for initialization
		void Start () 
		{

		}
		
		// Update is called once per frame
		void Update () 
		{
            if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") )
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
		}
	}
}
