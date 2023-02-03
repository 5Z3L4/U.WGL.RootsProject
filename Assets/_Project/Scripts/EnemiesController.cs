using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;

    [SerializeField] private List<Transform> _respawnPoints;
    [SerializeField] private float _respawnTime;
    [SerializeField] private float _respawnTimeOnStart;

    private float _timer;
    public bool IsPlayerDead = false;

    void Start()
    {
        _timer = _respawnTimeOnStart;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer < 0 && !IsPlayerDead)
        {
            _timer = _respawnTime;
            int pointNumber = Random.Range(0, _respawnPoints.Count);
            GameObject enemy = Instantiate(_enemyToSpawn, _respawnPoints[pointNumber]);
            enemy.GetComponent<Enemy>().SetEnemyData(this, _playerTransform, _speed);
        }
    }
}
