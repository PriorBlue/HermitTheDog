using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Target;
    public GameObject Prefab;
    public Color EffectColor;

    public float Delay = 5f;
    public bool SpawnOnStart = false;
    public int MaxSpawn = 1;
    public float DecreaseTime = 0f;

    private float timer = 0f;
    private List<GameObject> spawns = new List<GameObject>();

    private void Start()
    {
        if (SpawnOnStart)
        {
            timer = Delay;
        }
        else
        {
            timer = Delay * 0.5f;
        }
    }

    private void Update()
    {
        if (spawns.Count >= MaxSpawn)
        {
            spawns.RemoveAll(it => it == null);

            return;
        }

        if (timer < Delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            var unit = Instantiate(Prefab, transform.position, Quaternion.identity);

            spawns.Add(unit);

            if (Target != null)
            {
                var ai = unit.GetComponent<AIMovement>();

                if (ai != null)
                {
                    ai.Target = Target;
                }
            }

            if (Delay > 10)
            {
                Delay -= DecreaseTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = EffectColor;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
