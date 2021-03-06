﻿using UnityEngine;
using System.Collections;
using nDATACONTROL;
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
				DataControl.control.levelData.scoreSoulFragments += 1;
				source.PlayOneShot(sfxCollect);
                transform.GetChild(0).GetComponent<Animator>().SetBool("Collect", true);
			}

            if (collision.gameObject.tag == "Player" && IsCollected == false && m_type == Type.SOUL_SHARD)
            {
                IsCollected = true;
                DataControl.control.levelData.score += 10;
                transform.GetChild(0).GetComponent<Animator>().SetBool("Collect", true);
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
            if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") )
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
		}
	}
}
