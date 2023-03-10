using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public static EnemiesController Instance { get; private set; }
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private GameObject _enemyToSpawn;

    public Transform PlayerTransform;
    [SerializeField] private float _speed;

    [SerializeField] private List<Transform> _respawnPoints;

    [SerializeField] private float _respawnTime;
    [SerializeField] private float _respawnTimeOnStart;
    private float _playTime;

    private float _timer;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    private void Start()
    {
        _timer = _respawnTimeOnStart;
    }

    private void Update()
    {
        _playTime += Time.deltaTime;
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            _timer = _respawnTime;
            int pointNumber = Random.Range(0, _respawnPoints.Count);
            int pointNumber2 = Random.Range(0, _respawnPoints.Count);
            GameObject enemy = Instantiate(_enemyToSpawn, _respawnPoints[pointNumber]);
            GameObject enemy2 = Instantiate(_enemyToSpawn, _respawnPoints[pointNumber2]);
            enemy.GetComponent<Enemy>().SetEnemyData(this, _canvasManager, PlayerTransform, _speed);
            enemy2.GetComponent<Enemy>().SetEnemyData(this, _canvasManager, PlayerTransform, _speed);
        }

        if (_playTime >= 4)
        {
            if (_respawnTime <= 1.4) return;
            _respawnTime -= 0.2f;
            _playTime = 0;
        }
    }
}
