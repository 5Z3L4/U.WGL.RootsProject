using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    [SerializeField] public Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    public bool IsStarted;
    [SerializeField] private RootsManager _rootsManager;

    private void Start()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
    }

    private void Update()
    {
        if (!IsStarted) return;
        var distance = _speed * Time.deltaTime;
        
        //prob fix of nulls in list
        if (_playerPosition == null)
        {
            _playerPosition = _rootsManager.Water.transform;
            _rootsManager.TryGetTarget(); 
        }

        if (_playerPosition == null)
        {
            _playerPosition = _playerPosition = _rootsManager.Water.transform;;
        }
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
