using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public Transform Model;
    public Stunable Stun;
    public Chain BagCain;

    public float Speed = 1f;

    private float x = 0;
    private float y = 0;

    private void Update()
    {
        x = 0;
        y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            y += Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            y -= Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x -= Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x += Speed;
        }

        if (Stun.Stuned == false)
        {
            Rigid.velocity = new Vector2(x, y);
            Rigid.rotation = Vector2.SignedAngle(new Vector2(-x, y), Vector2.up);
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
