using UnityEngine;
using System.Collections;
using nSCENE;

namespace nENTITY
{
    public enum Team
    {
        PLAYER = 0,
        HOSTILE,
        NEUTRAL,
    }

    public enum Facing
    {
        LEFT = -1,
        RIGHT = 1
    }

    public enum State
    {
        ALIVE = 0,
        DEATH,
        WIN,
    }

    public class Entity : MonoBehaviour
    {
        public Facing m_facing;
        public State m_state;

        public Team m_team;
        public float maxFallSpeed;

        public bool IsPLATFORM;

        public Rigidbody2D m_rigid2D;
        protected Vector2 m_collisionNormals;
        protected Vector2 m_velocity;
        protected Vector2 m_lastFrameVelocity;
        protected Collision2D m_collision;
        protected bool IsINTERACTABLE;

        Facing m_lastFacing;

        float m_scaleX;

        bool m_IsDestroyed;
        bool m_ground;

        public bool IsDestroyed
        {
            get { return m_IsDestroyed; }
            set { m_IsDestroyed = value; }
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            //Entity _entity = collision.gameObject.GetComponent<Entity>();

            //Vector2 norms = Vector2.zero;
            //m_collisionNormals = Vector2.zero;

            //for (int i = 0; i < collision.contacts.Length; ++i)
            //{
            //    norms = collision.contacts[i].normal;
            //    m_collisionNormals += norms;
            //    m_collisionNormals.x = Mathf.Clamp(m_collisionNormals.x, -1.0f, 1.0f);
            //    m_collisionNormals.y = Mathf.Clamp(m_collisionNormals.y, -1.0f, 1.0f);

            //    Debug.DrawLine(collision.contacts[i].point, collision.contacts[i].point + collision.contacts[i].normal, Color.red);
            //}
            //Debug.DrawLine(transform.position, (transform.position + (Vector3)m_collisionNormals), Color.yellow);

            BoxCollider2D box = GetComponent<BoxCollider2D>();
            Vector2 _sizeCast = new Vector2(0.5f, 1.0f);

            if (box)
            {
                RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, _sizeCast, 0, Vector2.down, 0.1f, 1 << 13);
                if (hits != null && hits.Length > 0)
                {
                    m_ground = true;
                }
                else m_ground = false;
            }
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            m_ground = false;
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (IsPLATFORM)
            {
                BoxCollider2D _collider = gameObject.GetComponent<BoxCollider2D>();
                _collider.enabled = true;
            }
        }

        // Use this for initialization
        public virtual void Awake()
        {
            m_rigid2D = GetComponent<Rigidbody2D>();
            m_scaleX = transform.localScale.x;


            Vector3 scale = transform.localScale;
            scale.x = m_scaleX * (float)m_facing;
            transform.localScale = scale;
        }

        public bool IsOnGround()
        {
            return m_ground;
        }

        public bool Landed()
        {
            BoxCollider2D box = GetComponent<BoxCollider2D>();
            Vector2 _sizeCast = new Vector2(0.5f, 1.0f);

            if (box)
            {
                RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, _sizeCast, 0, Vector2.down, 0.2f, 1 << 13);
                if (hits != null && hits.Length > 0 && m_lastFrameVelocity.y < 0)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual bool IsPaused()
        {
            if (Scene.paused == true)
            {
                m_rigid2D.Sleep();
                return true;
            }

            m_rigid2D.WakeUp();
            return false;
        }

        new public void Update()
        {
            if (m_rigid2D == null) return;

            m_lastFacing = m_facing;

            m_lastFrameVelocity = m_velocity;

            m_velocity.x = m_rigid2D.velocity.x;

            m_velocity.y = m_rigid2D.velocity.y;

            Vector2 vel = m_rigid2D.velocity;
            if (m_velocity.y < maxFallSpeed)
            {
                m_velocity.y = maxFallSpeed;
            }

            m_rigid2D.velocity = m_velocity;
        }

        public void ChangeInFacing()
        {
            if (m_facing != m_lastFacing)
            {
                Vector3 scale = transform.localScale;
                scale.x = m_scaleX * (int)m_facing;
                transform.localScale = scale;
            }
        }

        public virtual void Damaged(int damage)
        {
            Die();
        }

        public virtual void Die()
        {

        }
    }
}
