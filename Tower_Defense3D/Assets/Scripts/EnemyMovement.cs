using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyManagement))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private EnemyManagement enemy;

    private void Start() {
        enemy = GetComponent<EnemyManagement>();
        if (Waypoints.points != null && Waypoints.points.Length > 0) {
            target = Waypoints.points[0];
        } else {
            Debug.LogError("Waypoints.points is null or empty!");
        }
    }
    private void Update() {
        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        if(wavepointIndex >= Waypoints.points.Length -1 ) {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    private void EndPath()
    {  
        PlayerStats.Lives --;
        Destroy(gameObject);
    }
}
