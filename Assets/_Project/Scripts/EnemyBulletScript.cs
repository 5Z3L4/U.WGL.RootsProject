using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _force;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player == null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Vector3 direction = _player.transform.position - transform.position;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _force;

        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }

        if (coll.collider.CompareTag("Player"))
        {
            _player.GetComponent<PlayController>().Die();
        }
    }
}
