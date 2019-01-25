using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform Target;

    public float Speed = 1f;
    public float StunTime = 1f;

    private Rigidbody2D rigid;

    private bool stuned = false;
    private float timer = 0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (stuned)
        {
            Vector2 vec = transform.position - Target.position;

            rigid.velocity = vec.normalized * Speed * 2f;

            if (timer < StunTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                stuned = false;
            }
        }
        else
        {
            Vector2 vec = Target.position - transform.position;

            rigid.velocity = vec.normalized * Speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            stuned = true;
        }
    }
}
