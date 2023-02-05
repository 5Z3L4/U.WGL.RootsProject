using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField] private CanvasManager _canvasManager;
    public void Die()
    {
        //play anim
        _canvasManager.DisplayDeathPanel();
    }
}
