using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunable : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public bool Stuned = false;

    public float StunTime = 1f;
    public float StunSpeed = 2f;

    private Vector2 StunDirection;

    private float timer = 0f;

    void FixedUpdate()
    {
        if (Stuned && Rigid.velocity != null)
        {
            Rigid.velocity = StunDirection * StunSpeed * Time.fixedDeltaTime;

            if (timer < StunTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                Stuned = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var stun = collision.gameObject.GetComponent<Stunable>();

        if (stun != null && collision.gameObject.tag != gameObject.tag)
        {
            StunDirection = (transform.position - collision.transform.position);
            StunDirection = StunDirection.normalized;

            Stuned = true;
        }
    }
}
