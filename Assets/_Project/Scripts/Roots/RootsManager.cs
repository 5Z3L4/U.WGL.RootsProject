using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RootsManager : Singleton<RootsManager>
{
    public FollowMouse CurrentFollow;
    public List<FollowMouse> AllRoots;
    public GameObject Water;
    public List<Transform> Targets = new();

    public void AddTarget(Transform target)
    {
        Targets.Add(target);
        CurrentFollow.ChangeTarget(Targets[0]);
    } 
    public void RemoveTarget(Transform target)
    {
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
        float lowestDistance = 1000;
        foreach (var root in AllRoots)
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
