using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public RectTransform Canvas;
    public Text HealthText;
    public Slider HealthSlider;
    public Image HealthBar;

    public Gradient HealthColor;

    public float HealthMax = 100f;

    private float health = 100f;
    private bool inBase = false;

    private void Start()
    {
        health = HealthMax;
        RefreshHealth();

        HealthText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (inBase)
        {
            health = Mathf.Clamp(health + Time.deltaTime * 10f, 0, HealthMax);
            RefreshHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var attack = collision.gameObject.GetComponent<Attack>();

        if (attack != null && collision.gameObject.tag != gameObject.tag)
        {
            health = Mathf.Clamp(health - attack.Damage, 0, HealthMax);
            RefreshHealth();

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Regen")
        {
            inBase = true;
        }

        var powerup = other.GetComponent<Powerup>();

        if (powerup != null)
        {
            HealthMax += powerup.MaxHealth;
            health = Mathf.Clamp(health + powerup.Health, 0, HealthMax);

            RefreshHealth();

            Destroy(powerup.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Regen")
        {
            inBase = false;
        }
    }

    public void RefreshHealth()
    {
        //HealthText.text = string.Format("{0:0}", health);
        HealthSlider.value = health / HealthMax;
        HealthBar.color = HealthColor.Evaluate(HealthSlider.value);

        Canvas.sizeDelta = new Vector2(HealthMax * 0.2f, 4f);

        //HealthText.gameObject.SetActive(health < HealthMax);
    }
}
