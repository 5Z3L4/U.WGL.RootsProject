using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    
    private void Update()
    {
        var distance = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
