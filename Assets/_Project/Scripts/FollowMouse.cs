using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject CurrentLine;

    public LineRenderer LineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> FingerPositions = new List<Vector2>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (FingerPositions.Count > 0 && Vector2.Distance(tempFingerPos, FingerPositions[^1]) > .1f)
            {
                UpdateLine(tempFingerPos);   
            }
        }
    }

    public void CreateLine()
    {
        if (LinePrefab == null) return;
        
        CurrentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer = CurrentLine.GetComponent<LineRenderer>();
        FingerPositions.Clear();
        FingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        FingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        LineRenderer.SetPosition(0, FingerPositions[0]);
        LineRenderer.SetPosition(1, FingerPositions[1]);
    }

    public void UpdateLine(Vector2 newFingerPosition)
    {
        FingerPositions.Add(newFingerPosition);
        LineRenderer.positionCount++;
        LineRenderer.SetPosition(LineRenderer.positionCount -1 , newFingerPosition);
        
    }
}
