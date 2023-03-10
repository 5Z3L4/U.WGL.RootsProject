using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    [SerializeField] private Transform _playerTransform;

    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private AudioSource _walkingSound;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if (_horizontal != 0 || _vertical != 0)//Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //_walkingSound.enabled = true;
        }
        else
        {
            //_walkingSound.enabled = false;
        }

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
