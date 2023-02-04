using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _enemyExplode;
    [SerializeField] private GameObject _enemySprite;
    [SerializeField] private ParticleSystem _bloodParticles;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Die();
        }   
    }

    private void Die()
    {
        StartCoroutine("WaitAndDestroy");
        _enemySprite.SetActive(false);
        _enemyExplode.SetActive(true);
        _bloodParticles.Play();
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
