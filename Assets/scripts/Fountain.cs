using UnityEngine;
using System.Collections;
using nSCENE;
using nFOLLOWCAMERA;

public class Fountain : MonoBehaviour 
{
    public float timer;
	public float delay;
	public float radius;
	public GameObject goal;
	public GameObject p_soulFragment;
	int m_count;
	bool triggerWin = false;

    public GameObject wall;

    delegate void WinSequence();

    WinSequence m_winSequence;

	// Use this for initialization
	void Start () 
	{
        m_winSequence = new WinSequence(Win0 );
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && triggerWin == false) 
		{
			Player _player = GameScene.gameScene.player.GetComponent<Player>();
			_player.SetState(nENTITY.State.WIN, ref _player.m_state);
			triggerWin = true;
            wall.SetActive(true);

		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(triggerWin)
		{
            m_winSequence();
		}
	}

    void Win0()
    {
        Player _player = GameScene.gameScene.player.GetComponent<Player>();
        if (_player.IsOnGround() )
        {
            Vector2 _pos = _player.transform.position;
            Vector2 _dest = new Vector2(_pos.x, _pos.y + 2.0f);
            _player.GetComponent<Translation>().SetTranslate(_pos, _dest);
            m_winSequence = new WinSequence(Win1);
        }
    }

	void Win1()
	{
        Player _player = GameScene.gameScene.player.GetComponent<Player>();
        if(_player.GetComponent<Translation>().AtDestination() )
        {
            m_winSequence = new WinSequence(Win2);
        }
	}

    void Win2()
    {
        timer += Time.deltaTime;
        Player _player = GameScene.gameScene.player.GetComponent<Player>();

        if (timer >= delay && m_count < GameScene.gameScene.currentSoulFragments)
        {
            float radius = 15.0f;
            float _xRand = Random.RandomRange(-1.0f, 1.0f);
            float _yRand = Random.RandomRange(-1.0f, 1.0f);

            GameObject soulFragment = (GameObject)Instantiate(p_soulFragment, _player.transform.position, _player.transform.rotation);
            soulFragment.GetComponent<Translation>().SetTranslate(soulFragment.transform.position, transform.position);
            soulFragment.GetComponent<Translation>().m_velocity = new Vector2(_xRand * radius, _yRand * radius);
            timer = 0;
            m_count += 1;
        }

        if (m_count >= GameScene.gameScene.currentSoulFragments) 
            m_winSequence = new WinSequence(Win3 );
    }
    void Win3()
    {
        Player _player = GameScene.gameScene.player.GetComponent<Player>();
        _player.SetState(nENTITY.State.ALIVE, ref _player.m_state);
        _player.disableControl = false;
        FollowCamera.control.gameObject.GetComponent<FollowCamera>().followObject = goal;
        goal.GetComponent<Goal>().OpenDoor();
        m_winSequence = new WinSequence(WinEnd);
    }

    void WinEnd()
    {

    }

}
