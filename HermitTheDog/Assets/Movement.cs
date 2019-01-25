using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public Text HealthText;
    public Slider HealthSlider;

    public float HealthMax = 100f;
    public float Speed = 1f;

    private float x = 0;
    private float y = 0;

    private float health = 100f;
    private bool inBase = false;

    private void Start()
    {
        health = HealthMax;
        RefreshHealth();
    }

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

        Rigid.velocity = new Vector2(x, y);

        if (inBase)
        {
            health = Mathf.Clamp(health + Time.deltaTime * 10f, 0, HealthMax);
            RefreshHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            health = Mathf.Clamp(health - 10f, 0, HealthMax);
            RefreshHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "base")
        {
            inBase = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "base")
        {
            inBase = false;
        }
    }

    public void RefreshHealth()
    {
        HealthText.text = string.Format("{0:0}", health);
        HealthSlider.value = health / HealthMax;
    }
}
