using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeavingBehaviour : MonoBehaviour, IManeuver
{
    public void Maneuver(Obstacle obstacle)
    {
        StartCoroutine(Weave(obstacle));
    }

    IEnumerator Weave(Obstacle obstacle)
    {
        float time;
        bool isReverse = false;
        float speed = obstacle.speed;
        Vector3 startPosition = obstacle.transform.position;
        Vector3 endPosition = startPosition;
        endPosition.x = obstacle.weavingDistance;

        while (true)
        {
            time = 0;
            Vector3 start = obstacle.transform.position;
            Vector3 end = (isReverse) ? startPosition : endPosition;

            while (time < speed)
            {
                obstacle.transform.position = Vector3.Lerp(start, end, time / speed);
                time += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(1);
            isReverse = !isReverse;
        }
    }
}
