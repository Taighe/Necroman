using UnityEngine;
using System.Collections;
using nSCENE;

public enum CatcherType
{
    TIMED,
    SWITCH,
}

public class SoulCatcher : MonoBehaviour 
{
    public CatcherType m_type;
    public GameObject[] linkObjects;
    public float time;
    public float delay;
    public bool activated;

    Material m_runes;
    Material m_spiritTracks;
   
    public GameObject p_soulParticle;
    Vector3 m_center = new Vector3(0.5f, 1.0f, 0);

    delegate void TypeFunction();
    TypeFunction m_func;
    GameObject m_object;

    void Start()
    {
        m_runes = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().material;
        m_spiritTracks = transform.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;

        for (int i = 1; i < transform.GetChild(1).transform.childCount; i++ )
        {
            transform.GetChild(1).GetChild(i).gameObject.GetComponent<MeshRenderer>().material = m_spiritTracks;
        }

        if(m_type == CatcherType.TIMED)
        {
            m_func = new TypeFunction(Timed);
        }
        if (m_type == CatcherType.SWITCH)
        {
            m_func = new TypeFunction(Switch);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soul" && activated == false)
        {
            activated = true;
            collision.gameObject.GetComponent<SoulParticle>().SetTarget(gameObject, m_center);
            
            //for(int i = 0; i < linkObjects.Length; i++)
            //{
            //    linkObjects[i].GetComponent<SwitchObject>().TurnOn();
            //}
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_object = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_object = null;
        }
    }

    void Update()
    {
        m_func();
    }

    void Timed()
    {
        Animator anim = GetComponent<Animator>();

        if (activated)
        {
            for (int i = 0; i < linkObjects.Length; i++)
            {
                linkObjects[i].GetComponent<SwitchObject>().TurnOn();
            }
            
            time += 1.0f * Time.deltaTime;
            float _percent = 1.0f - (time / delay);
            m_runes.SetFloat("_timeleft0to1", _percent);
            m_spiritTracks.SetFloat("_Fadeonoff", 1.0f);

            if (time >= delay || Input.GetButtonDown("Reset"))
            {
                activated = false;
                GameObject soulparticle = (GameObject)Instantiate(p_soulParticle, transform.position + m_center, transform.rotation);
                soulparticle.GetComponent<SoulParticle>().SetTarget(GameScene.gameScene.player, new Vector2(0, 0));
                soulparticle.gameObject.tag = "SoulCollect";
            }
        }
        else
        {
            m_spiritTracks.SetFloat("_Fadeonoff", 0);
            m_runes.SetFloat("_timeleft0to1", 1.0f);
            time = 0;

            for (int i = 0; i < linkObjects.Length; i++)
            {
                linkObjects[i].GetComponent<SwitchObject>().TurnOff();
            }
        }

        anim.SetBool("Active", activated);
    }

    void Switch()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Active", activated);

        if (activated)
        {
            m_spiritTracks.SetFloat("_Fadeonoff", 1.0f);
            if (Input.GetButtonDown("Reset") && IsWithinRadius(GameScene.gameScene.player))
            {
                activated = false;
                GameObject soulparticle = (GameObject)Instantiate(p_soulParticle, transform.position + m_center, transform.rotation);
                soulparticle.GetComponent<SoulParticle>().SetTarget(GameScene.gameScene.player, new Vector2(0, 0));
                soulparticle.gameObject.tag = "SoulCollect";

            }

            for (int i = 0; i < linkObjects.Length; i++)
            {
                linkObjects[i].GetComponent<SwitchObject>().TurnOn();
            }
        }
        else
        {
            m_spiritTracks.SetFloat("_Fadeonoff", 0);
            m_runes.SetFloat("_timeleft0to1", 1.0f);
            time = 0;

            for (int i = 0; i < linkObjects.Length; i++)
            {
                linkObjects[i].GetComponent<SwitchObject>().TurnOff();
            }
        }

    }

    bool IsWithinRadius(GameObject _object)
    {
        if (m_object != null) 
            return true;

        return false;
    }
}