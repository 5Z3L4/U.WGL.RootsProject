using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    public bool IsStarted;
    
    private void Update()
    {
        if (!IsStarted) return;
        var distance = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
