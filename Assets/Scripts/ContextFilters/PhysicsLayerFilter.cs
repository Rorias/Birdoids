using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/PhysicsLayer")]
public class PhysicsLayerFilter : ContextFilter2D
{
    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent2D _agent, List<Transform> _original)
    {
        List<Transform> filtered = new List<Transform>();

        for (int i = 0; i < _original.Count; i++)
        {
            if (mask == (mask | (1 << _original[i].gameObject.layer)))
            {
                filtered.Add(_original[i]);
            }
        }

        return filtered;
    }
}
