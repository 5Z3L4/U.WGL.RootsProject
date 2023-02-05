using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;

    private CanvasManager _canvasManager;
    private EnemiesController _enemiesController;
    private Transform _playerTransform;
    private float _enemySpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_enemiesController.IsPlayerDead) return;
        
        if(_playerTransform.position.x - transform.position.x > 0)
        {
            _rb.transform.localScale = new Vector3(.5f,.5f,.5f);
        }
        else if(_playerTransform.position.x - transform.position.x < 0)
        {
            _rb.transform.localScale = new Vector3(-.5f,.5f,.5f);;
        }
    }

    private void FixedUpdate()
    {
        if (_enemiesController.IsPlayerDead) return;

        _rb.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
    }

    public void SetEnemyData(EnemiesController enemiesController, CanvasManager deathManager, Transform playerTransform, float speed)
    {
        _enemiesController = enemiesController;
        _canvasManager = deathManager;
        _playerTransform = playerTransform;
        _enemySpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _enemiesController.IsPlayerDead = true;
            _canvasManager.DisplayDeathPanel();
            Destroy(collider.gameObject);
        }
    }
}
