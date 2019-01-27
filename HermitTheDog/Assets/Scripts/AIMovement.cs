using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform Target;
    public Transform Model;
    public Stunable Stun;

    public float Speed = 1f;

    private Rigidbody2D rigid;

    private Vector2 direction = new Vector2(1f, 0f);

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Stun.Stuned == false)
        {
            direction = Target.position - transform.position;

            rigid.velocity = direction.normalized * Speed;

            if (direction.x != 0 || direction.y != 0)
            {
                Model.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, 0f), Vector3.back);
            }
        }
    }
}
