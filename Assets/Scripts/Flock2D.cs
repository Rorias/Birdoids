using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Flock2D : MonoBehaviour
{
    public FlockAgent2D prefabAgent;
    private List<FlockAgent2D> agents = new List<FlockAgent2D>();
    public FlockBehaviour2D behaviour;

    [Range(10, 500)] public int startingCount = 200;

    private const float agentDensity = 0.08f;

    [Range(1f, 100f)] public float driveFactor = 10f;
    [Range(1f, 100f)] public float maxSpeed = 5f;
    [Range(1f, 10f)] public float neighborRadius = 1.5f;
    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeightborRadius;
    public float squareAvoidanceRadius { get; private set; } = 1f;

    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeightborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareAvoidanceRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        //Create all the agents that will be flying around in this particular flock
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent2D newAgent = Instantiate(prefabAgent, Random.insideUnitCircle * startingCount * agentDensity,
                                                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);

            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    private void Update()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            List<Transform> context = GetNearbyObjects(agents[i]);
            SetLightValue(agents[i], context);

            Vector2 move = behaviour.CalculateMove(agents[i], context, this);

            move *= driveFactor;
            //if agent is moving faster than allowed, limit it's speed to the max speed
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agents[i].Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent2D _agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(_agent.transform.position, neighborRadius);

        //for all the colliders hit within the circle of this agent
        for (int i = 0; i < contextColliders.Length; i++)
        {
            //if the collider isnt its own collider
            if (contextColliders[i] != _agent.agentCollider)
            {
                //add the transform of the hit agent to the context list
                context.Add(contextColliders[i].transform);
            }
        }

        return context;
    }

    private void SetLightValue(FlockAgent2D _agent, List<Transform> _context)
    {
        if (_agent.light2D != null)
        {
            //agents[i].GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            _agent.light2D.pointLightInnerRadius = Mathf.Lerp(0, 0.5f, _context.Count / 5f);
        }
    }
}
