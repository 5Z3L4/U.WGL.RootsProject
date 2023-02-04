using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggers : MonoBehaviour
{
    public FollowMouse Fm;
    public RootMovement Rm;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Root"))
        {
            if (RootsManager.Instance.CurrentFollow == null) return;
            
            RootsManager.Instance.CurrentFollow.ResetLine();
        }
    }
}
