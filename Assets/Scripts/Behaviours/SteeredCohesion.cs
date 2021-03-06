using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesion : FilteredFlockBehaviour2D
{
    private Vector2 currentVelocity = Vector2.zero;

    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock)
    {
        List<Transform> filteredContext = (filter == null) ? _context : filter.Filter(_agent, _context);

        //if no neighbors, return no adjustment
        if (filteredContext.Count == 0) { return _agent.transform.up; }

        //otherwise add all points together and average
        Vector2 cohesionMove = Vector2.zero;

        for (int i = 0; i < filteredContext.Count; i++)
        {
            cohesionMove += (Vector2)filteredContext[i].position;
        }
        cohesionMove /= filteredContext.Count;

        //create offset from agent position
        cohesionMove -= (Vector2)_agent.transform.position;

        cohesionMove = Vector2.SmoothDamp(_agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);

        return cohesionMove;
    }
}
