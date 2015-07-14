using UnityEngine;
using System.Collections;

public class RandomScaler : RandomMove {

  public float minScale = 0.7f;
  public float maxScale = 1.5f;
  public float minTime = 0.2f;
  public float maxTime = 0.8f;

  private float nextScale = 0.0f;
  private float lastScale = 0.0f;
  private float currentTime = 0.0f;
  private float targetTime = 0.0f;
  private float originalScale;

  void Start()
  {
    originalScale = transform.localScale.x;
    lastScale = 1.0f;
    nextScale = 0.0f;
  }

	void Update () {
    if (nextScale == 0.0f)
    {
      nextScale = Random.Range(minScale, maxScale);
      targetTime = Random.Range(minTime, maxTime);
      currentTime = 0.0f;
    }

    float scale = Mathf.Lerp(lastScale, nextScale, currentTime / targetTime);
    scale = scale * originalScale;
    Vector3 vecScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    transform.localScale = vecScale;
    currentTime += Time.deltaTime * getSpeed();

    if (currentTime > targetTime)
    {
      lastScale = nextScale;
      nextScale = 0.0f;
    }
	}
}
