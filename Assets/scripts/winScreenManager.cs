using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nDATACONTROL;

public class winScreenManager : MonoBehaviour 
{ 
	public GameObject p_soulFragment;

	public GameObject p_player;

	public float timer;

	public float delay;

	public float radius;

	public Text m_percentage;

	public int maxSoulFragments;

    public Text m_score;

    public Text m_rank;

    public int m_rankingScore;
	
	int m_count = 0;
    int m_totalScore;

    delegate void WinSequence();
    WinSequence m_winSequence;


	// Use this for initialization
	void Start () 
	{
        m_totalScore = DataControl.control.levelData.score;
        m_winSequence = new  WinSequence( Win0);
	}
	
	// Update is called once per frame
	void Update () 
	{
        m_winSequence();
		
        float percent = ((float)m_count / (float)maxSoulFragments) * 100;

        string _score = m_totalScore.ToString("00000");
        m_score.text = "Score: " + _score;

		m_percentage.text = "" + percent + " %";
	}

    void Win0()
    {
        timer += Time.deltaTime;
        if (timer >= delay && m_count < DataControl.control.levelData.scoreSoulFragments)
        {
            GameObject soulFragment = (GameObject)Instantiate(p_soulFragment, p_player.transform.position, p_player.transform.rotation);
            soulFragment.GetComponent<Translation>().SetTranslate(transform.position, m_percentage.transform.position);
            timer = 0;
            m_count += 1;

            m_totalScore += 15 * m_count;
        }
 
        if (m_count >= DataControl.control.levelData.scoreSoulFragments)
        {
            m_winSequence = new WinSequence(Win1);
        }
    }

    void Win1()
    {
        float _rankPercent = (float)m_totalScore / (float)m_rankingScore;

        if (_rankPercent >= 0 && _rankPercent <= 0.2f) m_rank.text = " D";
        if (_rankPercent >= 0.2f && _rankPercent <= 0.6f) m_rank.text = " C";
        if (_rankPercent >= 0.6f && _rankPercent < 1.0f) m_rank.text = " B";
        if (_rankPercent >= 1.0f) m_rank.text = " A";

        m_winSequence = new WinSequence(Win2);
    }

    void Win2()
    {

    }
}
