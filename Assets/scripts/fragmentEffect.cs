using UnityEngine;
using System.Collections;

public class fragmentEffect : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
	{
		Animator animator = transform.GetChild (0).GetComponent<Animator> ();

		if(GetComponent<Translation>().AtDestination() )
		{
			animator.SetBool("Collect", true);
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName("End"))
			Destroy (gameObject);
	}

}
