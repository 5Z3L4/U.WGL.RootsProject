using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private Camera _mainCamera;
    private Vector3 _mousePos;

    private void Start()
    {
        _mainCamera = Camera.main;
    }


    private void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = _mainCamera.transform.position.z + Camera.main.nearClipPlane;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_mousePos);
    }
}
