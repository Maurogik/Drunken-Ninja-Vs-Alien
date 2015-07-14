using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

  public static SpawnManager Instance = null;

  public Creature[] creatures;
  public float[] spawnFrames;

  private float currentTime = 0.0f;

  void Awake(){
    Instance = this;
  }

  public void StartLevel()
  {
    currentTime = 0.0f;
  }

	// Update is called once per frame
	void Update () {
    currentTime += Time.deltaTime;
	}

  public float GetTime()
  {
    return currentTime;
  }

  public GameObject SpawnCreatureAt(Vector3 position)
  {
    int indToSpawn = 0;
    for(int i = 0; i < spawnFrames.Length; ++i)
    {
      if(currentTime <= spawnFrames[i]){
        indToSpawn = i;
        break;
      }
    }
    GameObject creat = InstanceManager.InstantiateObject(creatures[indToSpawn].gameObject);
    Vector3 pos = position;
    pos.y = creat.GetComponent<CreatureAI>().startHeight;
    creat.transform.position = pos;
    return creat;
  }
}
