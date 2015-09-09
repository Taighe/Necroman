using UnityEngine;
using System.Collections;
using nENTITY;

public class Intro : MonoBehaviour 
{
	public void PlayIntro()
	{
		GameObject _player = transform.GetChild (0).gameObject;

		_player.GetComponent<Player> ().Intro();
	}
}