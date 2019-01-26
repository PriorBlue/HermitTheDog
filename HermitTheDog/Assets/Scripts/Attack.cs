using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var powerup = other.GetComponent<Powerup>();

        if (powerup != null)
        {
            Damage += powerup.Attack;

            Destroy(powerup.gameObject);
        }
    }
}
