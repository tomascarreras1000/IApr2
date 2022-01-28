using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CopBehaviour : MonoBehaviour
{
    private Moves movesScript;
    NavMeshAgent agent;
    private WaitForSeconds wait = new WaitForSeconds(0.05f); // == 1/20
    delegate IEnumerator State();
    private State state;
    public Transform copTransform;
    uint wanderSpeed = 2, stealSpeed = 4, hideSpeed = 4;
    bool isStealSuccessful = false; // TODO: Check if it ca be removed

    // Start is called before the first frame update
    public void Start()
    {
        movesScript = GetComponent<Moves>();
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(state());
    }

    
}
