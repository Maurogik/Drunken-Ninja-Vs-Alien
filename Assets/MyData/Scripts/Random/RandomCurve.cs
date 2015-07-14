using UnityEngine;
using System.Collections;

public class RandomCurve : MonoBehaviour {

  public float minTime = 0.2f;
  public float maxTime = 0.8f;

  private int lastCurveX = 0;
  private int nextCurveX = 0;
  private int lastCurveY = 0;
  private int nextCurveY = 0;

  private AbstractCurve curvator;

	// Use this for initialization
	void Start () {
    curvator = GetComponent<AbstractCurve>();
    renewAnimation();
    curvator.animationDone += renewAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	}

  private int getRandomCurve(int oldCurve)
  {
    int curve = Random.Range(0, GameData.curvesPrefab.Length);
    while (curve == oldCurve)
    {
      curve = Random.Range(0, GameData.curvesPrefab.Length);
    }
    return curve;
  }

  private void renewAnimation()
  {
    float targetTime = Random.Range(minTime, maxTime);
    lastCurveX = nextCurveX;
    nextCurveX = getRandomCurve(lastCurveX);
    lastCurveY = nextCurveY;
    nextCurveY = getRandomCurve(lastCurveY);
    curvator.SetCurveX(lastCurveX, nextCurveX, targetTime);
    curvator.SetCurveY(lastCurveY, nextCurveY, targetTime);
  }
}
