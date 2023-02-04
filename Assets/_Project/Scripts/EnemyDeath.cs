using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _enemyExplode;
    [SerializeField] private GameObject _enemySprite;
    [SerializeField] private GameObject _bloodParticles;
    [SerializeField] private GameObject _body;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Root"))
        {
            Die();
        }   
    }

    private void Die()
    {
        RootsManager.Instance.RemoveTarget(transform);
        GameObject body = Instantiate(_body, transform.position, Quaternion.identity);
        Destroy(body, 3);
        GameObject ExplosionParticlesIns = Instantiate(_bloodParticles, transform.position, Quaternion.identity);
        Destroy(ExplosionParticlesIns, 3);
        Destroy(gameObject);
    } 
}
