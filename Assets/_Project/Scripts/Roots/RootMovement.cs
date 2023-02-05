using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    [SerializeField] public Transform _playerPosition;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _baseSpeed = 2f;
    public bool IsStarted;
    [SerializeField] private RootsManager _rootsManager;

    private float _increaseTimerBase = 15;
    private float _increaseTimer;

    [SerializeField] private AudioSource _rootSound;

    private void Start()
    {
        _increaseTimer = _increaseTimerBase;
        _baseSpeed = _speed;
        _rootsManager = FindObjectOfType<RootsManager>();
    }

    private void Update()
    {
        if (_increaseTimer > 0)
        {
            _increaseTimer -= Time.deltaTime;
        }
        else
        {
            _increaseTimer = _increaseTimerBase;
            _baseSpeed += 0.2f;
        }

        if (!IsStarted)
        {
            _rootSound.enabled = false;
            return;
        }
        _rootSound.enabled = true;

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

        if (_playerPosition != _rootsManager.Water.transform)
        {
            _speed *= 1.03f;
        }
        else
        {
            _speed = _baseSpeed;
        }
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, distance);
    }
}
