using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour 
{
    public bool inverse;
    public bool active;

    void Start()
    {
        if(active)
        {
            TurnOn();
        }     
    }

    public void TurnOn()
    {
        bool _active = true;
        
        if (inverse)
            _active = false;

        GetComponent<Animator>().SetBool("Active", _active);
        GetComponent<Collider2D>().enabled = _active;
    }

    public void TurnOff()
    {
        bool _active = false;
        
        if (inverse)
            _active = true;
        
        GetComponent<Animator>().SetBool("Active", _active);
        GetComponent<Collider2D>().enabled = _active;
    }

}
