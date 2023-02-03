using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private float _horizontal;
    private float _vertical;
    private float _moveLimiter = 0.7f;
    
    [SerializeField] private float runSpeed = 2f;
    
    private void Start ()
    {
       _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
       _horizontal = Input.GetAxisRaw("Horizontal");
       _vertical = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            _horizontal *= _moveLimiter;
            _vertical *= _moveLimiter; 
        }

        _rb.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed) * (Time.fixedDeltaTime * 100);
    }
}