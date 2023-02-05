using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] private float _fieldOfImpact;
    [SerializeField] private float _force;

    [SerializeField] private LayerMask _layerToHit;
    [SerializeField] private bool _shouldPlaySound = true;
    [SerializeField] private AudioSource _explodeSound;

    private System.Random _rnd;

    private void Start()
    {
        _rnd = new System.Random();
    }

    private void OnEnable()
    {
        if (_shouldPlaySound)
        {
            _explodeSound.Play();
        }
        Explode();
    }

    public void Explode()
    {
        Collider2D [] objects = Physics2D.OverlapCircleAll(transform.position, _fieldOfImpact, _layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            var rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * _force, ForceMode2D.Impulse);
            rb.AddTorque(1, ForceMode2D.Impulse);
        }
    }
}
