using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;

    private EnemiesController _enemiesController;
    private Transform _playerTransform;
    private float _enemySpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_enemiesController.IsPlayerDead) return;

        _rb.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
    }

    public void SetEnemyData(EnemiesController enemiesController, Transform playerTransform, float speed)
    {
        _enemiesController = enemiesController;
        _playerTransform = playerTransform;
        _enemySpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _enemiesController.IsPlayerDead = true;
            Destroy(collider.gameObject);
        }
    }
}
