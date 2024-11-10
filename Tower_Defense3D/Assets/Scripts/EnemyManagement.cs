using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start() {
        if (Waypoints.points != null && Waypoints.points.Length > 0) {
            target = Waypoints.points[0];
        } else {
            Debug.LogError("Waypoints.points is null or empty!");
        }
    }

    private void Update() {
        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if(wavepointIndex >= Waypoints.points.Length -1 ) {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
