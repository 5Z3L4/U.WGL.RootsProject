                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using System;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Root"))
        {
            print("works");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GameController"))
        {
            if (RootsManager.Instance.CurrentFollow == null) return;
            
            RootsManager.Instance.CurrentFollow.ResetLine();
            RootsManager.Instance.ChoseRoot();
        }
    }
}
