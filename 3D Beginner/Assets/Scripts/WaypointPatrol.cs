using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;
    int propossedWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[(int)Random.Range(0, waypoints.Length)].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            do
            {
                propossedWaypoint = (int)Random.Range(0, waypoints.Length);
            } while (propossedWaypoint == m_CurrentWaypointIndex);
            m_CurrentWaypointIndex = propossedWaypoint;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
