using UnityEngine;
using System.Collections;

public class AbstractCurve : RandomMove {

  public event System.Action animationDone;

  public virtual void RecordFrameInEditor() { }
  public virtual void SetCurveX(int frame, int nextFrame, float duration) { }
  public virtual void SetCurveY(int frame, int nextFrame, float duration) { }
  public virtual void cleanAllFrames() { }

  protected void fireAnimationDone()
  {
    if (animationDone != null)
    {
      animationDone();
    }
  }
}
