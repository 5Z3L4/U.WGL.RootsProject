using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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
            GameObject enemy = Instantiate(_enemyToSpawn, _respawnPoints[pointNumber]);
            enemy.GetComponent<Enemy>().SetEnemyData(this, _canvasManager, PlayerTransform, _speed);
        }

        if (_playTime >= 15)
        {
            if (_respawnTime <= 1) return;
            _respawnTime -= 0.2f;
            _playTime = 0;
        }
    }
}
