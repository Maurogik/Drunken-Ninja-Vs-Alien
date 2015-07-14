using UnityEngine;
using System.Collections;

public class EmptyCurve : AbstractCurve {


  private AbstractCurve[] getAllCurves()
  {
    return GetComponentsInChildren<Curve>();
  }

  public override void RecordFrameInEditor()
  {
    foreach (AbstractCurve curve in getAllCurves())
    {
      curve.RecordFrameInEditor();
    }
  }

  public override void SetCurveX(int frame, int nextFrame, float duration)
  {
    foreach (AbstractCurve curve in getAllCurves())
    {
      curve.SetCurveX(frame, nextFrame, duration);
    }
  }

  public override void SetCurveY(int frame, int nextFrame, float duration)
  {
    foreach (AbstractCurve curve in getAllCurves())
    {
      curve.SetCurveY(frame, nextFrame, duration);
    }
  }

  public override void cleanAllFrames() 
  {
    foreach (AbstractCurve curve in getAllCurves())
    {
      curve.cleanAllFrames();
    }
  }
}
