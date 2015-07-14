using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

  void OnEnable()
  {
    UIMgr.Instance.HideMenu();
  }
}
