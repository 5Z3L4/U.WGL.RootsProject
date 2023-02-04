using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowMouse : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject CurrentLine;

    public LineRenderer LineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> FingerPositions = new List<Vector2>();

    public Transform StartPos;
    public GameObject FollowObj;
    public Transform FollowObjStartPos;

    private void Start()
    {
        CreateLine();
    }

    private void Update()
    {
        if (FingerPositions.Count > 0 && Vector2.Distance(FollowObj.transform.position, FingerPositions[^1]) > .1f)
        {
            UpdateLine(FollowObj.transform.position);
        }
    }

    //Creates base of root
    public void CreateLine()
    {
        if (LinePrefab == null) return;

        CurrentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer = CurrentLine.GetComponent<LineRenderer>();
        EdgeCollider = CurrentLine.GetComponent<EdgeCollider2D>();
        FingerPositions.Clear();
        FingerPositions.Add(StartPos.position);
        FingerPositions.Add(FollowObj.transform.position);
        LineRenderer.SetPosition(0, FingerPositions[0]);
        LineRenderer.SetPosition(1, FingerPositions[1]);
        EdgeCollider.points = FingerPositions.ToArray();
    }

    //Movement of Apex
    public void UpdateLine(Vector2 newFingerPosition)
    {
        FingerPositions.Add(newFingerPosition);
        LineRenderer.positionCount++;
        LineRenderer.SetPosition(LineRenderer.positionCount -1 , newFingerPosition);
        EdgeCollider.points = FingerPositions.ToArray();
    }

    [ContextMenu("Reset")]
    public void ResetLine()
    {
        Destroy(CurrentLine);
        FingerPositions.Clear();
        FollowObj.transform.position = FollowObjStartPos.position;
        CreateLine();
    }
}
