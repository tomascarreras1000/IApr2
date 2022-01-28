using UnityEngine;
using UnityEngine.AI;

public class Moves : MonoBehaviour
{
    public GameObject target;
    public Collider floor;
    public NavMeshAgent agent;
    public GameObject robber;
    public GameObject treasure;
    public bool found = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        floor = GameObject.Find("Floor").GetComponent<MeshCollider>();
        agent = GetComponent<NavMeshAgent>();
        robber = GameObject.Find("Robber");
        treasure = GameObject.Find("Treasure");

        if (transform.name.Contains("4")) 
            target = treasure;
        else
            target = robber;
        
        Wander();
    }

    void Update()
    {
        if (gameManager.isFormationRequired)
            agent.destination = target.transform.position;
        if (!found && agent.remainingDistance < 2)
            Wander();

        if (Vector3.Distance(transform.position, robber.transform.position) < 4)
        {
            if (!gameManager.isFormationRequired)
                Debug.Log("Robber Found! Form Up!");
            gameManager.isFormationRequired = true;
        }
    }

    public void BBSeekRobber() 
    {
        target = robber;
        found = true;
    }

    public void BBSeekTreasure() 
    {
        target = treasure;
        found = true;
    }

    public void Wander()
    {
        float radius = 5;
        float distance = 7;

        Vector3 target = Vector3.zero;

        target += new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        target.Normalize();
        target *= radius;

        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(target + 
                                                new Vector3(0, 0, distance));

        if (!floor.bounds.Contains(targetWorld))
        {
            targetWorld = -transform.position * 0.1f;
        };

        agent.destination = targetWorld;
    }
}
