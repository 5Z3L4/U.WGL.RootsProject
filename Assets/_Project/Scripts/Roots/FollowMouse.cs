using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowMouse : MonoBehaviour
{
    private GameObject _linePrefab;
    public GameObject CurrentLine;

    public PrefabsHolder PrefabsHolder;
    public LineRenderer LineRenderer;
    public EdgeCollider2D EdgeCollider;
    public List<Vector2> FingerPositions = new List<Vector2>();

    public Transform StartPos;
    public GameObject FollowObj;
    public Transform FollowObjStartPos;

    public RootMovement Rm;

    [SerializeField] private RootsManager _rootsManager;

    private void Awake()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
    }
    private void Start()
    {
        _linePrefab = PrefabsHolder.UsedRoot;
        CreateLine();
    }

    private void Update()
    {
        if (FingerPositions.Count > 0 && Vector2.Distance(FollowObj.transform.position, FingerPositions[^1]) > .1f)
        {
            UpdateLine(FollowObj.transform.position);
        }
    }

    [ContextMenu("StartMovement")]
    public void StartMovement()
    {
        Rm.IsStarted = true;
        _rootsManager.CurrentFollow = this;
    }

    public void ChangeTarget(Transform target)
    {
        Rm._playerPosition = target;
    }

    //Creates base of root
    public void CreateLine()
    {
        if (_linePrefab == null) return;

        CurrentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity);
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
        CurrentLine.GetComponent<EdgeCollider2D>().enabled = true;
        FingerPositions.Add(newFingerPosition);
        LineRenderer.positionCount++;
        LineRenderer.SetPosition(LineRenderer.positionCount -1 , newFingerPosition);
        EdgeCollider.points = FingerPositions.ToArray();
    }

    [ContextMenu("Reset")]
    public void ResetLine()
    {
        CurrentLine.GetComponent<EdgeCollider2D>().enabled = false;
        _rootsManager.Targets.Clear();
        FingerPositions.Clear();
        FollowObj.transform.position = FollowObjStartPos.position;
        Rm.IsStarted = false;
        StartCoroutine(DestroyRoot());
        
    }

    private IEnumerator DestroyRoot()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(CurrentLine);
        CreateLine();
        _rootsManager.ChoseRoot();
    }
}
