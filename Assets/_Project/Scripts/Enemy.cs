using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Material _tagMaterial;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private SpriteRenderer _spriteTagged;
    private Rigidbody2D _rb;

    private EnemiesController _enemiesController;
    private Transform _playerTransform;
    private float _enemySpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_playerTransform == null) return;  
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
        if (_playerTransform == null) return;    
        _rb.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
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

    public void TagEnemy()
    {
        StartCoroutine(StartTaggingEnemy());
    }

    private IEnumerator StartTaggingEnemy()
    {
        _sprite.gameObject.SetActive(false);
        _spriteTagged.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _sprite.gameObject.SetActive(true);
        _spriteTagged.gameObject.SetActive(false);
    }
}
