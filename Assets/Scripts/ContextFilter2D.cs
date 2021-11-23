using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContextFilter2D : ScriptableObject
{
    public abstract List<Transform> Filter(FlockAgent2D _agent, List<Transform> _original);
}