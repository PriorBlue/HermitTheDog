using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PopupMessage Popup;

    public float Damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var powerup = collision.gameObject.GetComponent<Powerup>();

        if (powerup != null)
        {
            Damage += powerup.Attack;

            if (Popup != null && powerup.Attack > 0)
            {
                Popup.CreatePopup(powerup.Attack, powerup);
            }

            Destroy(powerup.gameObject);
        }
    }
}
