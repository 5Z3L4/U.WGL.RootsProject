using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggers : MonoBehaviour
{
    [SerializeField] private RootsManager _rootsManager;

    private void Awake()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish") && WaterController.Instance.CanTagEnemy)
        {
            //TODO: instead of this add this obj to follow list 
            if (_rootsManager.CurrentFollow == null) return;
            _rootsManager.AddTarget(col.transform);
        }
    }
}
