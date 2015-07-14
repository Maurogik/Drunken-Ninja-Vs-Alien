using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

  public float bulletTimeScale = 0.5f;
  public float hitBulletTimeDuration = 0.5f;
  public float deathBulletTimeDuration = 1.0f;
  public static TimeManager Instance = null;

  private float lastScale = 0.0f;
  private string methodName = "cancelBulletTime";

  void Awake()
  {
    Instance = this;
  }

  public void Pause()
  {
    if (Time.timeScale > 0.0f)
    {
      lastScale = Time.timeScale;
      Time.timeScale = 0.0f;
    }
  }

  void OnDisable()
  {
    Time.timeScale = 1.0f;
  }

  public bool IsPaused()
  {
    return Time.timeScale == 0.0f;
  }

  public void Resume()
  {
    if (Time.timeScale == 0.0f)
    {
      Time.timeScale = lastScale;
    }
  }

  public void BulletTimeHit()
  {
    Time.timeScale = bulletTimeScale;
    CancelInvoke(methodName);
    Invoke(methodName, hitBulletTimeDuration);
  }

  public void BulletTimeDeath()
  {
    Time.timeScale = bulletTimeScale;
    CancelInvoke(methodName);
    Invoke(methodName, deathBulletTimeDuration);
  }

  private void cancelBulletTime()
  {
    Time.timeScale = 1.0f;
  }
}
