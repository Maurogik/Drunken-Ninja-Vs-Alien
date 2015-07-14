using UnityEngine;
using System.Collections;

public class UpdateScore : MonoBehaviour {

  void OnEnable()
  {
    GetComponent<TextMesh>().text = "Score : " + GameData.score;
  }
}
