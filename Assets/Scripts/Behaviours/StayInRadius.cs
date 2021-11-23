using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRadius")]
public class StayInRadius : FlockBehaviour2D
{
    public Vector2 center;

    public float radius;

    public override Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock)
    {
        Vector2 centerOffset = center - (Vector2)_agent.transform.position;
        float t = centerOffset.magnitude / radius;

        if (t < 0.9f) { return _agent.transform.up; }

        return centerOffset * t * t;
    }
}
