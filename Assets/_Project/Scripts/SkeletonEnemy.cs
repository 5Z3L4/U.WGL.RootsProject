using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;

    private EnemiesController _enemiesController;
    private Transform _playerTransform;
    private float _enemySpeed;

    [SerializeField] private float _distance = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_playerTransform == null) return;
        if (_playerTransform.position.x - transform.position.x > 0)
        {
            _rb.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (_playerTransform.position.x - transform.position.x < 0)
        {
            _rb.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        if (_playerTransform == null) return;

        if (Vector2.Distance(transform.position, _playerTransform.position) >= _distance)
        {
            _rb.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
        }
    }

    public void SetEnemyData(EnemiesController enemiesController, CanvasManager deathManager, Transform playerTransform, float speed)
    {
        _enemiesController = enemiesController;
        _playerTransform = playerTransform;
        _enemySpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<PlayController>().Die();
            Destroy(collider.gameObject);
        }
    }
}
