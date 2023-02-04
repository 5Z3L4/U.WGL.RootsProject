using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAnimator : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    [SerializeField] private Transform _playerTransform;

    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _sprite;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if (_horizontal == 0) return;

        Vector3 localScale = _sprite.transform.localScale;
        _sprite.transform.localScale = _horizontal < 0 ? new Vector3(-0.75f, 0.75f) : new Vector3(0.75f, 0.75f);
    }

    private void FixedUpdate()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
}
