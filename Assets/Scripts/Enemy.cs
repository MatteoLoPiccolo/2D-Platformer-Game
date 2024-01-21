using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using static UnityEditor.LightmapEditorSettings;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _checkForGround;
    [SerializeField] PlayerController _playerController;

    private void Update()
    {
        CheckForGround();
    }

    private void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_checkForGround.position, Vector2.down, 3.0f);

        if (hit.collider != null)
        {
            MoveRight();
        }
        else
        {
            ReverseDirectionAndSpeed();
        }
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }

    private void ReverseDirectionAndSpeed()
    {
        _speed *= -1;
        float rotationY = (_speed > 0) ? 0 : 180;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player grab collectible");

            if (_playerController != null)
            {
                _playerController.Die();
            }
        }
    }
}
