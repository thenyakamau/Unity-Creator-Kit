using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float speed = 2f;
    [SerializeField] private bool isDelay = false;

    private int currentWayPointIndex = 0;
    private float delayTime = .5f;

    private bool playingDelay = false;

    // Update is called once per frame
    private void Update()
    {
        Vector2 position = waypoints[currentWayPointIndex].transform.position;
        float distance = Vector2.Distance(position, transform.position);

        if (distance < 1f)
        {
            currentWayPointIndex++;

            if (currentWayPointIndex >= waypoints.Length)
                currentWayPointIndex = 0;

        }

        if (isDelay && distance < 1.08f)
        {
            if (!playingDelay)
            {
                StartCoroutine(ControlDecent(position));
                playingDelay = true;
            }

        }
        else SetPosition(position);
    }

    private IEnumerator ControlDecent(Vector2 currentPosition)
    {
        yield return new WaitForSeconds(delayTime);
        SetPosition(currentPosition);
        playingDelay = false;
    }

    private void SetPosition(Vector2 currentPosition)
    {
        float distanceTraveled = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, currentPosition, distanceTraveled);
    }
}
