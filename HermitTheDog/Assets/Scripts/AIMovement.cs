using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform Target;
    public Stunable Stun;

    public float Speed = 1f;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Stun.Stuned == false)
        {
            Vector2 vec = Target.position - transform.position;

            rigid.velocity = vec.normalized * Speed;
        }
    }
}
