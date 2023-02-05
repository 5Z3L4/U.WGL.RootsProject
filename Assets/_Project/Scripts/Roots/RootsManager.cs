using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RootsManager : MonoBehaviour
{
    public FollowMouse CurrentFollow;
    public List<FollowMouse> AllRoots = null;
    public GameObject Water;
    public List<Transform> Targets = new();
    public WaterController _wc;
    private bool _didOnce;

    private void Start()
    {
        ChoseRoot();
    }

    public void AddTarget(Transform target)
    {
        if (Targets.Contains(target)) return;
        
        WaterController.Instance.DecreaseWater();
        Targets.Add(target);
        CurrentFollow.ChangeTarget(Targets[0]);
    }  
    
    public void TryGetTarget()
    {
        if (Targets.Count > 0)
        {
            CurrentFollow.ChangeTarget(Targets[0]);
        }
    }

    private void Update()
    {
        if (!WaterController.Instance.CanTagEnemy && Targets.Count == 0 &&!_didOnce)
        {
            CurrentFollow.ResetLine();
            CurrentFollow.ChangeTarget(Water.transform);
            _didOnce = true;
        }

        if (WaterController.Instance.CanTagEnemy && Targets.Count > 0)
        {
            _didOnce = false;
        }
    }

    public void RemoveTarget(Transform target)
    {
        if (!Targets.Contains(target)) return;
        
        if (Targets.Count > 1)
        {
            CurrentFollow.ChangeTarget(Targets[1]);
        }
        else
        {
            CurrentFollow.ChangeTarget(Water.transform);
        }

        Targets.Remove(target);
    }

    public void ChoseRoot()
    {
        if (!_wc.CanTagEnemy) return;
        
        float lowestDistance = 1000;
        List<FollowMouse> fm = new List<FollowMouse> { CurrentFollow};
        foreach (var root in AllRoots.Except(fm))
        {
            if (Vector2.Distance(root.transform.position, Water.transform.position) < lowestDistance)
            {
                lowestDistance = Vector2.Distance(root.transform.position, Water.transform.position);
                CurrentFollow = root;
            }
        }
        CurrentFollow.StartMovement();
    }
}
