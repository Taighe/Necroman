using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour 
{

    public void TurnOn()
    {
        GetComponent<Animator>().SetBool("Active", true);
        GetComponent<EdgeCollider2D>().enabled = true;
    }

    public void TurnOff()
    {
        GetComponent<Animator>().SetBool("Active", false);
        GetComponent<EdgeCollider2D>().enabled = false;
    }

}
