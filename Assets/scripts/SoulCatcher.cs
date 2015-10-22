using UnityEngine;
using System.Collections;
using nSCENE;

enum Type
{
    eTIME,
}

public class SoulCatcher : MonoBehaviour 
{
    public bool activated;
    public Material spiritMaterial;
    public GameObject[] linkObjects;
    public float time;
    public float delay;
   
    public GameObject p_soulParticle;
    Vector3 m_center = new Vector3(0.5f, 1.0f, 0);

    void Start()
    {
        float _temp = spiritMaterial.GetFloat("_Fadeonoff");
        _temp = 0;
        spiritMaterial.SetFloat("_Fadeonoff", _temp);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soul" && activated == false)
        {
            activated = true;
            collision.gameObject.GetComponent<SoulParticle>().SetTarget(this.gameObject, m_center);
            for(int i = 0; i < linkObjects.Length; i++)
            {
                linkObjects[i].GetComponent<SwitchObject>().TurnOn();
            }
        }
    }

    void Update()
    {
        Animator anim = GetComponent<Animator>();

        if (activated) 
        {
            time += 1.0f * Time.deltaTime;
            
            float _temp = spiritMaterial.GetFloat("_Fadeonoff");
            _temp = 1;
            spiritMaterial.SetFloat("_Fadeonoff", _temp);

            if(time >= delay || Input.GetButtonDown("Reset"))
            {
                activated = false;
                GameObject soulparticle = (GameObject)Instantiate(p_soulParticle, transform.position + m_center, transform.rotation);
                soulparticle.GetComponent<SoulParticle>().SetTarget(GameScene.gameScene.player, new Vector2(0,0));
                soulparticle.gameObject.tag = "SoulCollect";

                for (int i = 0; i < linkObjects.Length; i++)
                {
                    linkObjects[i].GetComponent<SwitchObject>().TurnOff();
                }
            }
        }
        else 
        {
            float _temp = spiritMaterial.GetFloat("_Fadeonoff");
            _temp = 0;
            spiritMaterial.SetFloat("_Fadeonoff", _temp);
 
            time = 0;
        }

        anim.SetBool("Active", activated);
    }

}
