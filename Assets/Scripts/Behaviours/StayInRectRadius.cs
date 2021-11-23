using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/StayInRectRadius")]
public class StayInRectRadius : FlockBehaviour2D
{
    public Vector2 center;
    public Vector2 radius;

    public override Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock)
    {
        Vector2 centerOffset = center - (Vector2)_agent.transform.position;
        float tx = centerOffset.magnitude / radius.x;
        float ty = centerOffset.magnitude / radius.y;

        if (tx < 0.9f) { return _agent.transform.up; }
        if (ty < 0.9f) { return _agent.transform.up; }

        Vector2 t = new Vector2(centerOffset.x * tx * tx, centerOffset.y * ty * ty);

        return t;
    }
}
