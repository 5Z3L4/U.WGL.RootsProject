using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplode : MonoBehaviour
{
    private CanvasManager _canvasManager;
    private void Awake()
    {
         _canvasManager = FindObjectOfType<CanvasManager>();
         StartCoroutine(DisplayDeathPanel());
    }
    private IEnumerator DisplayDeathPanel()
    {
        yield return new WaitForSeconds(0.3f);
        _canvasManager.DisplayDeathPanel();
    }
}
