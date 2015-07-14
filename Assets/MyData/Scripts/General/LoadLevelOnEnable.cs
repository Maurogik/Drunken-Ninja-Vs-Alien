using UnityEngine;
using System.Collections;

public class LoadLevelOnEnable : MonoBehaviour {

  public string levelToLoad;

  void OnEnable()
  {
    GameData.reloadingLevel = true;
    Application.LoadLevel(levelToLoad);
  }
}
