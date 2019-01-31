using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public RectTransform Canvas;
    public Text HealthText;
    public Slider HealthSlider;
    public Image HealthBar;
    public PopupMessage Popup;
    public Drop Drop;

    public Gradient HealthColor;

    public float HealthMax = 100f;

    public float Defence = 0f;

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
        if (health < HealthMax)
        {
            if (inBase)
            {
                health = Mathf.Clamp(health + Time.deltaTime * 10f, 0, HealthMax);
            }
            else
            {
                health = Mathf.Clamp(health + Time.deltaTime * 2f, 0, HealthMax);
            }

            RefreshHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var attack = collision.gameObject.GetComponent<Attack>();

        if (attack != null && collision.gameObject.tag != gameObject.tag)
        {
            var damage = Mathf.Max(attack.Damage - Defence, 1f);

            health = Mathf.Clamp(health - damage, 0, HealthMax);
            RefreshHealth();

            if (Popup != null && gameObject.tag != "Player")
            {
                Popup.CreatePopup(damage, Color.red);
            }

            if (health <= 0f)
            {
                if (gameObject.tag == "Player")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (Drop != null)
                {
                    Drop.DropStuff();
                }

                Destroy(gameObject);
            }
        }

        var powerup = collision.gameObject.GetComponent<Powerup>();

        if (powerup != null)
        {
            HealthMax += powerup.MaxHealth;
            health = Mathf.Clamp(health + powerup.Health, 0, HealthMax);

            RefreshHealth();

            if (powerup.MaxHealth > 0f)
            {
                Popup.CreatePopup(powerup.MaxHealth, powerup);
            }
            else if (powerup.Health > 0f)
            {
                Popup.CreatePopup(powerup.Health, powerup);
            }

            if (powerup.Defence > 0f)
            {
                Popup.CreatePopup(powerup.Defence, powerup);
            }

            Destroy(powerup.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Regen")
        {
            inBase = true;
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
        HealthSlider.value = health / HealthMax;
        HealthBar.color = HealthColor.Evaluate(HealthSlider.value);

        Canvas.sizeDelta = new Vector2(HealthMax * 0.2f, 4f);
    }
}
