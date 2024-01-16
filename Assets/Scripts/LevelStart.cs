using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit start level trigger!");
        }
    }
}