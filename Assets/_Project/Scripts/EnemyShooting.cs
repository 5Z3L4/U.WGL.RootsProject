using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _distance = 10f;
    private float _timer;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _timer += Time.deltaTime;  
        
        if (_timer >= 4)
        {
            _timer = 0;

            if (_player != null)
            {
                if (Vector2.Distance(transform.position, _player.transform.position) <= _distance)
                {
                    Shoot();
                }
            }
             
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _bulletPosition.position, _bulletPosition.rotation);
    }
}
