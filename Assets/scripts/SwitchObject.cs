using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour 
{
    public bool inverse;
<<<<<<< HEAD
    public bool active;

    void Start()
    {
        if(active)
        {
            TurnOn();
        }     
    }
=======
>>>>>>> 21dc313385a69ec8ab09a283464716e27b7ab483

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
