using UnityEngine;
using System.Collections;
using nENTITY;

public class Intro : MonoBehaviour 
{

	public void PlayIntro()
	{
		Animator animState = GetComponent<Animator> ();
		animState.SetBool ("Start", true);
	}
	
	public void PlayPlayerIntro()
	{
		GameObject _player = transform.GetChild (0).gameObject;

		_player.GetComponent<Player> ().Intro();
	}
}