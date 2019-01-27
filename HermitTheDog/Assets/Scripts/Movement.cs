using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public Transform Model;
    public Stunable Stun;
    public Chain BagCain;
    public Animator Animator;

    public float Speed = 1f;

    private Vector2 direction = new Vector3(0f, 0f);

    private void Update()
    {
        direction = new Vector3(0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        var isWalking = direction.x != 0f || direction.y != 0f;

        if (isWalking)
        {
            Model.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, 0f), Vector3.back);
        }

        Animator.SetBool("walk", isWalking);

        if (Stun.Stuned == false)
        {
            Rigid.velocity = direction.normalized * Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var powerup = other.GetComponent<Powerup>();

        if (powerup != null)
        {
            Speed += powerup.Speed;

            BagCain.AddChain(powerup.Chain);

            Destroy(powerup.gameObject);
        }
    }
}
