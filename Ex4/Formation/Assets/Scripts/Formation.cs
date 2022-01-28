using UnityEngine;
using UnityEngine.AI;

public class Formation : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Vector3 pos;
    public Quaternion rot;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject go = GameObject.Find("Cop 1");
        if (go != gameObject)
            target = go;
        else
            target = null;

        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        if (target != null)
        {
            transform.rotation = target.transform.rotation;
            transform.position = target.transform.TransformPoint(pos);
        }
    }

    void Update()
    {
        if (target != null && gameManager.isFormationRequired && !transform.name.Contains("4"))
            agent.destination = target.transform.TransformPoint(pos);
    }
}
