using UnityEngine;
using System.Collections;
using nDATACONTROL;
using UnityEngine.UI;

public class LevelSelectGUI : MonoBehaviour 
{
    public Text worldFragments;
    
    //Level Details Panel
    public Text levelName;
    public Text soulFragments;
    public Text score;
    public GameObject requirement;

	// Use this for initialization
	void Start () 
    {
        worldFragments.text = " x " + DataControl.control.m_worldFragments;
	}
	
	// Update is called once per frame
	void Update () 
    {
        int _soulFragments = DataControl.control.levelData.scoreSoulFragments;
        string _levelName = DataControl.control.levelData.levelName;
        int _score = DataControl.control.levelData.score;

        levelName.text = "";
        soulFragments.text = "";
        score.text = "";
        requirement.SetActive(false);

        if (DataControl.control.levelData.passedRequirement == false && DataControl.control.levelData.soulFragmentRequirement > 0)
        {
            requirement.SetActive(true);
            requirement.GetComponent<Text>().text = "Locked    x " + DataControl.control.levelData.soulFragmentRequirement;
            return;
        }

        //Display values
        levelName.text = _levelName;
        soulFragments.text = _soulFragments + " / 10";
        score.text = "Score " + _score;
	}
}
