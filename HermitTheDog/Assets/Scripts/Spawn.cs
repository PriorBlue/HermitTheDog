using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Target;
    public GameObject Prefab;

    public float Delay = 5f;

    private float timer = 0f;

    private void Start()
    {
        timer = Delay * 0.75f;
    }

    private void Update()
    {
        if (timer < Delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            var unit = Instantiate(Prefab, transform.position, Quaternion.identity);

            var ai = unit.GetComponent<AIMovement>();

            if (ai != null)
            {
                ai.Target = Target;
            }

            if (Delay > 10)
            {
                Delay -= 2;
            }
        }
    }
}
