using UnityEngine;
using System.Collections;

public class RandomRotation : RandomMove {

  public float minRotation = -60.0f;
  public float maxRotation = 100.0f;
  public float minTime = 0.2f;
  public float maxTime = 0.8f;

  private float currentTime = 0.0f;
  private float targetTime = 0.0f;
  private Quaternion lastQuat;
  private Quaternion nextQuat;
  private Quaternion originalQuat;

  void Start()
  {
    originalQuat = transform.localRotation;
    lastQuat = Quaternion.identity;
    nextQuat = randomQuaternion();
    targetTime = Random.Range(minTime, maxTime);
  }

	void Update () {
    currentTime += Time.deltaTime * getSpeed();
    if (currentTime > targetTime)
    {
      currentTime = 0.0f;
      lastQuat = nextQuat;
      nextQuat = randomQuaternion();
      targetTime = Random.Range(minTime, maxTime);
    }
    else
    {
      Quaternion quat = Quaternion.Lerp(lastQuat, nextQuat, currentTime / targetTime);
      transform.localRotation = originalQuat * quat;
    }
	}

  private Quaternion randomQuaternion()
  {
    float rot = Random.Range(minRotation, maxRotation);
    return Quaternion.AngleAxis(rot, Vector3.forward);
  }
}
