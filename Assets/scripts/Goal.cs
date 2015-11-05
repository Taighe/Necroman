using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nLEVELDATA;
using nSCENE;
using nCOLLECTABLE;

public class Goal : MonoBehaviour 
{
	public string scene;
	public float delay;
	float m_timer;
	bool m_IsOpen;
    public bool m_isTransition;

	Animator m_animator;

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if(Input.GetAxis("Vertical") > 0 )
			{
				m_IsOpen = true;
                if (m_isTransition) OpenDoor();
			}
		}
	}

	public void EndLevel()
	{
		if(m_timer >= delay)
		{
			DataControl.control.levelData.scoreSoulFragments = GameScene.gameScene.currentSoulFragments;
            DataControl.control.levelData.score = GameScene.gameScene.score;
			DataControl.control.levelData.time = GameScene.gameScene.levelTime;

			GameObject _collectable = GameScene.gameScene.gameObject.transform.GetChild (1).gameObject;
//
			for (int i = 0; i < GameScene.gameScene.totalSoulFragments; i++) 
			{
				DataControl.control.levelData.collectedSouls[i] = _collectable.transform.GetChild(i).GetComponent<Collectable>().IsCollected;
			}
//
//			if(DataControl.control.levelData.nextlevel != "")
//			{
//				LevelData _lastlevel = DataControl.control.levelData;
//				DataControl.control.levelData = GameObject.Find(DataControl.control.levelData.nextlevel).GetComponent<LevelData>();
//				DataControl.control.levelData.unlocked = true;
//				DataControl.control.levelData = _lastlevel;
//			}

			//DataControl.control.levelData.timeAttackMode = true;
			
			//DataControl.control.Save();

			Application.LoadLevel(scene);
		}

	}
	
	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_IsOpen == true) 
		{
			m_timer += Time.deltaTime;
			GameScene.gameScene.player.GetComponent<Player>().disableControl = true;
			GameScene.gameScene.player.GetComponent<Player>().Exit();
		}

		EndLevel();
	}

    public void OpenDoor()
    {
        m_animator.SetBool("Open", true);
    }
}
