using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent2D : MonoBehaviour
{
    public Flock2D agentFlock { get; private set; }

    public Collider2D agentCollider { get; private set; }
    public Light2D light2D { get; private set; }

    private void Awake()
    {
        agentCollider = GetComponent<Collider2D>();
        light2D = GetComponentInChildren<Light2D>();
    }

    public void Initialize(Flock2D _flock)
    {
        agentFlock = _flock;
    }

    public void Move(Vector2 _direction)
    {
        transform.up = _direction;
        transform.position += (Vector3)_direction * Time.deltaTime;
    }
}
