using UnityEngine;

public class Agent1 : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float speed = 5.0f;
    public float playerDistanceThreshold = 5.0f;
    public float targetDistanceThreshold = 3.0f;

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if (targetDistance < targetDistanceThreshold)
        {
            if (playerDistance < playerDistanceThreshold)
            {
                Vector3 direction = transform.position - player.transform.position;
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
            else
            {
                Vector3 direction = player.transform.position - transform.position;
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
