using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    [SerializeField] public Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    public bool IsStarted;
    
    private void Update()
    {
        if (!IsStarted) return;
        var distance = _speed * Time.deltaTime;
        
        //prob fix of nulls in list
        if (_playerPosition == null)
        {
            _playerPosition = RootsManager.Instance.Water.transform;
            RootsManager.Instance.TryGetTarget(); 
        }

        if (_playerPosition == null)
        {
            _playerPosition = _playerPosition = RootsManager.Instance.Water.transform;;
        }
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
