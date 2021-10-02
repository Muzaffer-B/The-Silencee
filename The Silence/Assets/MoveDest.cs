using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveDest : MonoBehaviour
{
    public GameObject characterdestination;
    NavMeshAgent theAgent;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        theAgent.SetDestination(characterdestination.transform.position);
    }
}
