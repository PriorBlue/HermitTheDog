using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform Target;
    public Transform Model;
    public Stunable Stun;
    public Animator Animator;

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

            rigid.velocity = direction.normalized * Speed * Time.deltaTime;

            var isWalking = direction.x != 0f || direction.y != 0f;

            if (isWalking)
            {
                Model.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, 0f), Vector3.back);
            }

            Animator.SetBool("walk", isWalking);
        }
    }
}
