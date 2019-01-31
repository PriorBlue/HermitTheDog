using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceInfo : MonoBehaviour
{
    public Text Info;
    public Transform Target;
    public List<Transform> Units;

    private void Update()
    {
        var distance = 999f;

        Units.RemoveAll(it => it == null);

        foreach (var unit in Units)
        {
            var newDist = Vector3.Distance(Target.position, unit.position);

            if (newDist < distance)
            {
                distance = newDist;
            }
        }

        Info.text = string.Format("{0:0}m", distance);
    }
}
