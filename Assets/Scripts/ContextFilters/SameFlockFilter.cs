using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/SameFlock")]
public class SameFlockFilter : ContextFilter2D
{
    public override List<Transform> Filter(FlockAgent2D _agent, List<Transform> _original)
    {
        List<Transform> filtered = new List<Transform>();

        for (int i = 0; i < _original.Count; i++)
        {
            FlockAgent2D agent = _original[i].GetComponent<FlockAgent2D>();

            if (agent != null && agent.agentFlock == _agent.agentFlock)
            {
                filtered.Add(_original[i]);
            }
        }

        return filtered;
    }
}
