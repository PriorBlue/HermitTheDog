using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PopupMessage Popup;

    public float Damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var powerup = other.GetComponent<Powerup>();

        if (powerup != null)
        {
            Damage += powerup.Attack;

            if (Popup != null && powerup.Attack > 0)
            {
                Popup.CreatePopup("+ " + powerup.Attack + " ATK", Color.yellow);
            }

            Destroy(powerup.gameObject);
        }
    }
}
