using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
	public Material material;
	public Vector2 tiling;

	Material m_material;

	// Use this for initialization
	void Awake()
	{	
		if(material == null) 
			return;
		
		m_material = Instantiate(material);
		m_material.mainTextureScale = tiling;
		GetComponent<SpriteRenderer> ().material = m_material;

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
