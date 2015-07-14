using UnityEngine;
using System.Collections;

public class ExitOnEnable : MonoBehaviour {

  void OnEnable()
  {
    Application.Quit();
  }
}
