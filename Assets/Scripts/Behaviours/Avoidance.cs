using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class Avoidance : FilteredFlockBehaviour2D
{
    public override Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock)
    {
        List<Transform> filteredContext = (filter == null) ? _context : filter.Filter(_agent, _context);

        //if no neighbors, return no adjustment
        if (filteredContext.Count == 0) { return _agent.transform.up; }

        //otherwise add all points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;

        for (int i = 0; i < filteredContext.Count; i++)
        {
            if (Vector2.SqrMagnitude(_agent.transform.position - filteredContext[i].position) < _flock.squareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(_agent.transform.position - filteredContext[i].position);
            }
        }

        if (nAvoid > 0) { avoidanceMove /= nAvoid; }

        return avoidanceMove;
    }
}
