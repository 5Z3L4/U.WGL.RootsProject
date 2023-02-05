using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsHolder : MonoBehaviour
{
    public GameObject KretRoot;
    public GameObject NormalRoot;
    public bool KretMode;
    public GameObject UsedRoot;

    private void Awake()
    {
        if (KretMode)
        {
            UsedRoot = KretRoot;
        }
        else
        {
            UsedRoot = NormalRoot;
        }
    }
}
