using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish") && WaterController.Instance.CanTagEnemy)
        {
            //TODO: instead of this add this obj to follow list 
            if (RootsManager.Instance.CurrentFollow == null) return;
            RootsManager.Instance.AddTarget(col.transform);
        }
    }
}
