using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        _rb.MovePosition(mousePosition); //= mousePosition;
    }
}
