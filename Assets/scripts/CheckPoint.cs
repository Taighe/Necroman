using UnityEngine;
using System.Collections;
using nSCENE;

public class CheckPoint : MonoBehaviour 
{
	Animator m_animator;
	bool m_active;

	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator>();
		m_active = false;
	}

	public void Activate()
	{
		m_active = true;
		m_animator.SetBool ("active", m_active);
	}

	// Update is called once per frame
	void Update () 
	{
		if(GameScene.gameScene.currentCheckpoint != this.gameObject)
		{
			m_active = false;
			m_animator.SetBool ("active", m_active);
		}
	}
}
