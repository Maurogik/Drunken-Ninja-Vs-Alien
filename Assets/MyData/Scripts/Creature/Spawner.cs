using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

  public float spawnEverySecond = 8.0f;
  public float startDelay = 0.0f;
  private float nextSpawn;

  void Start()
  {
    nextSpawn = 0.0f;
  }

  public void Reset()
  {
    nextSpawn = 0.0f;
  }

	// Update is called once per frame
	void Update () {

    if (TimeManager.Instance.IsPaused())
    {
      return;
    }

    float time = SpawnManager.Instance.GetTime() - startDelay;
    if (time > nextSpawn)
    {
      nextSpawn += spawnEverySecond;
      Spawn();
    }
	}

  public void Spawn()
  {
    SpawnManager.Instance.SpawnCreatureAt(transform.position);
  }
}
