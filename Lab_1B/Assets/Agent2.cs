using UnityEngine;

public class Agent2 : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject agent1;
    public float speed = 5.0f;
    public float agent1DistanceThreshold = 3.0f;

    private enum State
    {
        ChasePlayer,
        ChaseTarget,
        Flee
    }

    private State currentState = State.ChasePlayer;

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        float agent1Distance = Vector3.Distance(transform.position, agent1.transform.position);

        switch (currentState)
        {
            case State.ChasePlayer:
                if (playerDistance > targetDistance && agent1Distance > agent1DistanceThreshold)
                {
                    currentState = State.ChaseTarget;
                }
                else if (agent1Distance <= agent1DistanceThreshold)
                {
                    currentState = State.Flee;
                }
                break;

            case State.ChaseTarget:
                if (targetDistance > playerDistance && agent1Distance > agent1DistanceThreshold)
                {
                    currentState = State.ChasePlayer;
                }
                else if (agent1Distance <= agent1DistanceThreshold)
                {
                    currentState = State.Flee;
                }
                break;

            case State.Flee:
                if (agent1Distance > agent1DistanceThreshold)
                {
                    if (playerDistance > targetDistance)
                    {
                        currentState = State.ChaseTarget;
                    }
                    else
                    {
                        currentState = State.ChasePlayer;
                    }
                }
                break;
        }

        switch (currentState)
        {
            case State.ChasePlayer:
                Vector3 direction = player.transform.position - transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime);
                break;

            case State.ChaseTarget:
                direction = target.transform.position - transform.position;
                if (direction.magnitude > 1)
                {
                    transform.Translate(direction.normalized * speed * Time.deltaTime);
                }
                break;

            case State.Flee:
                direction = transform.position - agent1.transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime);
                break;
        }
    }
}
