                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using System;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCollisions : MonoBehaviour
{
    [SerializeField] private RootsManager _rootsManager;

    private void Start()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayController>().Die();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GameController"))
        {
            if (_rootsManager.CurrentFollow == null) return;
            
            FindObjectOfType<WaterController>().DecreaseWater();
            _rootsManager.CurrentFollow.ResetLine();
        }
    }
}
