using UnityEngine;
using System.Collections;

public class PausingObject : MonoBehaviour {

  void OnEnable()
  {
    TimeManager.Instance.Pause();
  }

  void OnDisable()
  {
    TimeManager.Instance.Resume();
  }
}
