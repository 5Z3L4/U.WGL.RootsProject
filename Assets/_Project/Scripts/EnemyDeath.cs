using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _enemyExplode;
    [SerializeField] private GameObject _enemySprite;
    [SerializeField] private GameObject _bloodParticles;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Root"))
        {
            Die();
        }   
    }

    private void Die()
    {
        StartCoroutine("WaitAndDestroy");
        _enemySprite.SetActive(false);
        _enemyExplode.SetActive(true);
        GameObject ExplosionParticlesIns = Instantiate(_bloodParticles, transform.position, Quaternion.identity);
        Destroy(ExplosionParticlesIns, 3);
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
