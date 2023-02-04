using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance is null)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];
                if (objs.Length > 0)
                {
                    _instance = objs[0];
                }

                if (_instance is null)
                {
                    GameObject obj = new GameObject
                    {
                        name = string.Format("_{0}", typeof(T).Name)
                    };
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
}