using UnityEngine;
using System.Collections;

public class EnableIfAlive : MonoBehaviour {

  public GameObject ifAliveTarget = null;
  public GameObject ifDeadTarget = null;

  void OnEnable()
  {
    ifAliveTarget.SetActive(GameData.playerAlive);
    ifDeadTarget.SetActive(!GameData.playerAlive);
  }
}
