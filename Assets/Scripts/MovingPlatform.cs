using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingPlatform : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        // Inizializza la posizione di destinazione alla posizione di partenza (pointA)
        targetPosition = pointA.position;
    }

    void Update()
    {
        // Muovi la piattaforma verso la posizione di destinazione
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Se la piattaforma è sufficientemente vicina alla posizione di destinazione, inverti la destinazione
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (targetPosition == pointA.position)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
        }
    }
}