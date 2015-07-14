using UnityEngine;
using System.Collections;

public class EnableForPlatform : MonoBehaviour {

  public bool web = false;
  public bool standalone = false;

  void OnEnable()
  {
#if UNITY_STANDALONE
    gameObject.SetActive(standalone);
#elif UNITY_WEBPLAYER
    gameObject.SetActive(web);
#endif
  }
}
