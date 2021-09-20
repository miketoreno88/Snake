using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float DistanceTail;

    public List<Transform> snakeCircles = new List<Transform>();
    public List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        positions.Add(SnakeHead.position);

    }
    private void Update()
    {
        float distance = ((Vector3) SnakeHead.position - positions[0]).magnitude;

        if (distance > DistanceTail)
        {
            // Направление от старого положения головы, к новому
            Vector3 direction = ((Vector3) SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * DistanceTail);
            positions.RemoveAt(positions.Count - 1);

            distance -= DistanceTail;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / DistanceTail);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        circle.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        Destroy(circle.GetComponent<HeadEat>());
        Destroy(circle.GetComponent<PlusOne>());
    }

}
