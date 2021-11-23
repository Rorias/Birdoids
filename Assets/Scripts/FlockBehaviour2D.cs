using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class FlockBehaviour2D : ScriptableObject
{
    public abstract Vector2 CalculateMove(FlockAgent2D _agent, List<Transform> _context, Flock2D _flock);
}
