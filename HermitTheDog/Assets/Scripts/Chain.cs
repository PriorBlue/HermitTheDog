using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public DistanceJoint2D ChainPrefab;
    public int ChainCount = 1;
    public float ChainGap = 0.1f;

    public DistanceJoint2D Source;
    public Rigidbody2D Target;

    private List<DistanceJoint2D> joints;

    private void Start()
    {
        joints = new List<DistanceJoint2D>();

        for (var i = 0; i < ChainCount; i++)
        {
            var chain = Instantiate(ChainPrefab, transform.position, Quaternion.identity);
            var rigid = chain.GetComponent<Rigidbody2D>();

            chain.distance = ChainGap;

            if (i == 0)
            {
                Source.connectedBody = rigid;
            }
            else
            {
                joints[i - 1].connectedBody = rigid;
            }


            if (i == ChainCount - 1)
            {
                chain.connectedBody = Target;
            }

            joints.Add(chain);
        }
    }

    public void AddChain(int cnt)
    {
        for (var i = 0; i < cnt; i++)
        {
            var chain = Instantiate(ChainPrefab, Target.position, Quaternion.identity);
            var rigid = chain.GetComponent<Rigidbody2D>();

            joints[joints.Count - 1].connectedBody = rigid;

            chain.distance = ChainGap;

            chain.connectedBody = Target;

            joints.Add(chain);
        }
    }
}
