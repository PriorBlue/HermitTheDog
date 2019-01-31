using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public AIMovement Movement;
    public float DropRate = 90f;
    public List<GameObject> Drops;
    public float RareDropRate = 10f;
    public List<GameObject> RareDrops;

    public void DropStuff()
    {
        if (RareDrops.Count > 0 && Random.Range(0f, 100f) <= RareDropRate)
        {
            var item = Instantiate(RareDrops[Random.Range(0, RareDrops.Count)], transform.position, Quaternion.identity);

            item.GetComponent<Rigidbody2D>().velocity = (transform.position - Movement.Target.position).normalized * 2f;
        }
        else if (Drops.Count > 0 && Random.Range(0f, 100f) <= DropRate)
        {
            var item = Instantiate(Drops[Random.Range(0, Drops.Count)], transform.position, Quaternion.identity);

            item.GetComponent<Rigidbody2D>().velocity = (transform.position - Movement.Target.position).normalized * 2f;
        }
    }
}
