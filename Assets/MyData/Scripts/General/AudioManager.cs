using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

  public float minPich = 0.6f;
  public float maxPitch = 1.0f;
	// Update is called once per frame
	void Update () {
    /*float dif = maxPitch - minPich;
    dif *= Time.timeScale;
    audio.pitch = minPich + dif;*/
    if (TimeManager.Instance.IsPaused())
    {
      audio.volume = 0.1f;
    }
    else
    {
      audio.volume = 1.0f;
    }
	}
}
