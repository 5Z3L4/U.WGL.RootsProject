using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] private float _fieldOfImpact;
    [SerializeField] private float _force;

    [SerializeField] private LayerMask _layerToHit;

    private void OnEnable()
    {
        Explode();
    }

    public void Explode()
    {
        Collider2D [] objects = Physics2D.OverlapCircleAll(transform.position, _fieldOfImpact, _layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * _force);
        }
    }
}
