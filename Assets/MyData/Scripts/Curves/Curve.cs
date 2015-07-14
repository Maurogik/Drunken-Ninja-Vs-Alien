using UnityEngine;
using System.Collections.Generic;

public enum Orientation {
  HORIZONTAL,
  VERTICAL
}

[ExecuteInEditMode()]
public class Curve : AbstractCurve
{
  private CurvePrefab currentCurveX;
  private CurvePrefab currentCurveY;


  public Transform extremity;
  public Orientation orientation;
  
  [SerializeField]
  private LineRenderer lineRenderer;

  public LineRenderer LineRenderer
  {
    get {
      if (lineRenderer == null)
      {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetWidth(0.1f, 0.1f);
      }
      return lineRenderer; 
    }
    set { lineRenderer = value; }
  }
  public int nbPoints;
  public bool recordFrame = false; 

  private CurvePrefab nextCurveX = null;
  private CurvePrefab nextCurveY = null;
  private float currentTime = 0.0f;
  private float targetTime = 0.0f;

  private void init()
  {
    Debug.Log("init");

  }

  public override void SetCurveX(int frame, int nextFrame, float duration)
  {
    targetTime = duration;
    currentTime = 0.0f;

    currentCurveX = GameData.curvesPrefab[frame];

    nextCurveX = GameData.curvesPrefab[nextFrame];
  }

  public override void SetCurveY(int frame, int nextFrame, float duration)
  {
    targetTime = duration;
    currentTime = 0.0f;

    currentCurveY = GameData.curvesPrefab[frame];
    nextCurveY = GameData.curvesPrefab[nextFrame];
  }

  private void runtimeDraw()
  {
    float step = 1.0f / (float)(nbPoints - 1);
    LineRenderer.SetVertexCount(nbPoints);
    for (int i = 0; i < nbPoints; ++i)
    {
      LineRenderer.SetPosition(i, computePosAt(i, step));
    }
    if (extremity != null)
    {
      Vector3 prevPoint = computePosAt(nbPoints - 2, step);
      Vector3 lastPoint = computePosAt(nbPoints, step);
      Vector3 dir = lastPoint - prevPoint;
      extremity.position = transform.TransformPoint(lastPoint);
      extremity.LookAt(extremity.position + transform.TransformDirection(dir));
    }
  }

  private Vector3 computePosAt(int i, float step)
  {
    float px, py, nx, ny, pz, nz;
    px = i * step;
    py = currentCurveX.curve.Evaluate(i * step);
    pz = currentCurveY.curve.Evaluate(i * step);

    nx = px;
    ny = nextCurveX.curve.Evaluate(i * step);
    nz = nextCurveY.curve.Evaluate(i * step);

    Vector3 prevPos = new Vector3(px, py, pz);
    Vector3 nextPos = new Vector3(nx, ny, nz);
    float progress = currentTime / targetTime;
    return Vector3.Lerp(prevPos, nextPos, progress);
  }


  void Update()
  {
    if (!Application.isPlaying)
    {
      /*if (recordFrame)
      {
        recordFrame = false;
        RecordFrameInEditor();
      }
      editorDraw();*/
    }
    else
    {
      if (currentTime > targetTime)
      {
        fireAnimationDone();
      }
      runtimeDraw();
      currentTime += Time.deltaTime * getSpeed();
    }
  }
}
