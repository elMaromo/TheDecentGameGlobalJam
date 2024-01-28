using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlataformaMovil : MonoBehaviour
{
    #region Variables
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 2.0f;

    int currentWaypointIndex = 0;
    bool playerDetected = false;
    Transform player;
    #endregion 

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No se han definido waypoints para la plataforma.");
            return;
        }

        MoveToWaypoint();

        if (HasReachedWaypoint())
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        if (playerDetected && player != null)
        {
            player.parent = transform;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.parent = null;
            playerDetected = false;
        }
    }

    void MoveToWaypoint()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;

        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        Vector3 moveAmount = moveDirection * speed * Time.deltaTime;

        transform.Translate(moveAmount);
    }

    bool HasReachedWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        return distanceToWaypoint < 0.1f;
    }
}