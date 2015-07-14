using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class CurveMgr : EmptyCurve {

  public bool recordAll = false;
  public bool clearAll = false;

  public void PlayFrameForMgr(int frame)
  {
    //base.PlayFrame(frame);
  }

	void Update ()
  {
    if (Application.isPlaying)
    {
    }
    else
    {
      if (recordAll)
      {
        recordAll = false;
        RecordFrameInEditor();
      }

      if (clearAll)
      {
        clearAll = false;
        cleanAllFrames();
      }
    }
	}
}
