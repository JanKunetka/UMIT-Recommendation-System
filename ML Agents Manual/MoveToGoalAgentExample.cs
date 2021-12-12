using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

/// <summary>
/// The brain of the agent, that learns, how to reach a goal.
/// </summary>
public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 randomOffset;
    [Space] 
    [SerializeField] private MeshRenderer progressRenderer;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material failMaterial;

    private Vector3 startingPosition;
    private Vector3 targetStartingPosition;

    private void Start()
    {
        //Cache starting positions for agent and target.
        startingPosition = transform.localPosition;
        targetStartingPosition = target.localPosition;
    }

    public override void OnEpisodeBegin()
    {
        //Set a random position of agent and target.
        transform.localPosition = startingPosition + new Vector3(Random.Range(-randomOffset.x, randomOffset.x), 0, Random.Range(-randomOffset.y, randomOffset.y));
        target.localPosition = targetStartingPosition + new Vector3(Random.Range(-randomOffset.x, randomOffset.x), 0, Random.Range(-randomOffset.y, randomOffset.y));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Register observations (2 different positions that must meet.)
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        //Register vector actions as movement
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //For debugging we assign manual controls to the agent.
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;

        continuousActions[0] = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        continuousActions[1] = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Reward the agent for successfully touching the goal.
        if (other.CompareTag("Agent Tests/Target Goal"))
        {
            progressRenderer.material = winMaterial;
            AddReward(1f);
            EndEpisode();
        }

        //..and cancel him for terrible decisions.
        if (other.CompareTag("Agent Tests/Agent Death"))
        {
            progressRenderer.material = failMaterial;
            AddReward(-1f);
            EndEpisode();
        }
    }
}
