using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
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
		material = m_material;
		m_material.mainTextureScale = tiling;
		GetComponent<SpriteRenderer> ().material = m_material;

	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
