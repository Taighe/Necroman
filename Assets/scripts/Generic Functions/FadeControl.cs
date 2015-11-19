using UnityEngine;
using System.Collections;

public class FadeControl : MonoBehaviour 
{
	public float speed;
	public float delay;
	public float timer;

	public CanvasGroup canvasGroup0;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime * speed;

		float alpha = timer / delay;

		canvasGroup0.alpha = alpha;
	}
}
