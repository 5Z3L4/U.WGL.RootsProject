using System;
using UnityEngine;

public class PrefabsHolder : MonoBehaviour
{
    public GameObject KretRoot;
    public GameObject NormalRoot;
    public bool KretMode;
    public GameObject UsedRoot;

    private void Awake()
    {
        KretMode = Convert.ToBoolean(PlayerPrefs.GetInt("KretMode", 0));

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
