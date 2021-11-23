using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class Alignment : FilteredFlockBehaviour2D
{
    public override Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock)
    {
        List<Transform> filteredContext = (filter == null) ? _context : filter.Filter(_agent, _context);

        //if no neighbors, keep current alignment and direction
        if (filteredContext.Count == 0) { return _agent.transform.up; }

        //otherwise add all points together and average
        Vector2 alignmentMove = Vector2.zero;

        for (int i = 0; i < filteredContext.Count; i++)
        {
            alignmentMove += (Vector2)filteredContext[i].up;
        }
        alignmentMove /= filteredContext.Count;

        return alignmentMove;
    }
}
