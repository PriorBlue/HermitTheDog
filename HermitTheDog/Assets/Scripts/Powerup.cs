using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Transform Bubble;

    public float Health = 0f;
    public float MaxHealth = 0f;
    public float Speed = 0f;
    public float Attack = 0f;
    public float Defence = 0f;
    public int Chain = 0;

    private float rand;

    private void Start()
    {
        rand = Random.Range(0f, 100f);
    }

    private void Update()
    {
        Bubble.position = new Vector3(Bubble.position.x, Bubble.position.y, (Mathf.Sin((Time.time + rand) * 2f) + 1f) * -0.1f - 0.1f);
        Bubble.localScale = new Vector3(0.2f, 0.2f, 0.2f) * ((Mathf.Cos((Time.time + rand) * 5f) * 0.1f) + 1f);
    }
}
