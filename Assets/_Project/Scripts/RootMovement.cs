using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _isStarted;
    
    private void Update()
    {
        if (!_isStarted) return;
        var distance = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
