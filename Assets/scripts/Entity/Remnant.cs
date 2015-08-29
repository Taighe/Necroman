using UnityEngine;
using System.Collections;
using nENTITY;

namespace nREMNANT
{
	public class Remnant : Entity 
	{
		// Use this for initialization
		void Start () 
		{
		
		}

		// Update is called once per frame
		void Update () 
		{

		}

		public override void Die()
		{
			Destroy (this.gameObject);
		}
	}
}
