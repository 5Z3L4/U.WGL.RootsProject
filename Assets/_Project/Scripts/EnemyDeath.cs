using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _enemyExplode;
    [SerializeField] private GameObject _enemySprite;
    [SerializeField] private GameObject _bloodParticles;
    [SerializeField] private GameObject _body;

    [SerializeField] private RootsManager _rootsManager;

    private void Start()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Root"))
        {
            ComboSystem.Instance.IncreaseStreak();
            Die();
        }   
    }

    private void Die()
    {
        _rootsManager.RemoveTarget(transform);
        GameObject body = Instantiate(_body, transform.position, Quaternion.identity);
        Destroy(body, 3);
        GameObject ExplosionParticlesIns = Instantiate(_bloodParticles, transform.position, Quaternion.identity);
        Destroy(ExplosionParticlesIns, 3);
        Destroy(gameObject);
    } 
}
